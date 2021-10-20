using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using QuizLibrary.Entities;
using QuizLibrary.Stores;
using QuizApi.Exceptions;

namespace QuizApi
{
    public class Quiz : IQuiz
    {
        public Quiz(string _section, int? _quizId, Account.Authorizer _authorizer)
        {
            _questions = (from quiz in store.Instance.QuizStore_.Quiz
                          from section in quiz.Sections
                          from question in section.Questions
                          from answer in question.Answers
                          where section.Name == _section
                          where _quizId != null ? quiz.Id == _quizId : true
                          select question).Distinct().Take(_numberQuestion);
            _ended = false;
            _position = 0;

            authorizer = _authorizer;
            quizId = _quizId;
            section = _section;
        }

        private Store store = new Store();
        private Account.Authorizer authorizer;
        private int? quizId;
        private string section;

        private int _numberQuestion = 20;
        private bool _ended;
        private int _position;
        private IEnumerable<Question> _questions;
        private Dictionary<int, List<string>> _answers = new Dictionary<int, List<string>>();

        public int Position => _position;
        public int LowerLimitPosition => 0;
        public int UpperLimitPosition => _numberQuestion;
        public string Question => _questions.ElementAt(_position).Text;
        public IEnumerable<string> Answers => from answer in _questions.ElementAt(_position).Answers select answer.Text;
        public bool IsSeveralCorrectAnswers => _questions.ElementAt(_position).IsSeveralCorrectAnswers;

        public void NextPosition()
        {
            _position++;
        }
        public void SetAnswer(List<string> answers)
        {
            _answers.Add(_position, answers);
        }
        public ResultItem FinishQuiz()
        {
            if (!_ended)
            {
                _ended = true;
                int correct = 0;

                foreach (var item in _answers)
                {
                    var rightAnswers = from answerOriginal in _questions.ElementAt(item.Key).Answers
                                       where answerOriginal.IsCorrectAnswer == true
                                       select answerOriginal.Text;

                    if (rightAnswers.Union(item.Value).Count() == rightAnswers.Count())
                        correct++;
                }

                var result = new Result
                {
                    AccountLogin = authorizer.Login,
                    QuizId = quizId,
                    SectionName = section,
                    NumberCorrectAnswer = correct,
                };
                var resultItem = new ResultItem
                {
                    AccountLogin = authorizer.Login,
                    QuizId = quizId,
                    SectionName = section,
                    NumberCorrectAnswer = correct,
                };
                store.Instance.ResultStore_.Add(result);
                return resultItem;
            }
            throw new QuizAlreadyEndedException();
        }
    }
}
