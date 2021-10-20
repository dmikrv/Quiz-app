using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using QuizLibrary.Entities;
using QuizLibrary.Stores;

namespace QuizApi
{
    public class Handbook
    {
        Store store = new Store();

        public IEnumerable<string> GetSections()
        {
            return (from quiz in store.Instance.QuizStore_.Quiz
                   from section in quiz.Sections
                   select section.Name).Distinct();
        }

        public IEnumerable<string> GetSections(string quizName)
        {
            return (from quiz in store.Instance.QuizStore_.Quiz
                   from section in quiz.Sections
                   where quiz.Name.ToLower() == quizName.ToLower()
                   select section.Name).Distinct();
        }

        public IEnumerable<QuizItem> GetQuiz()
        {
            return from quiz in store.Instance.QuizStore_.Quiz
                   select new QuizItem { Id = quiz.Id, Name = quiz.Name, Author = quiz.AuthorLogin };
        }

        public IEnumerable<ResultItem> GetResults()
        {
            return from result in store.Instance.ResultStore_.Results
                   select new ResultItem { AccountLogin = result.AccountLogin, QuizId = result.QuizId, 
                       NumberCorrectAnswer = result.NumberCorrectAnswer, SectionName = result.SectionName };
        }
    }
}
