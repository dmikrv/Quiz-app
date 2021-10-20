using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi
{
    public interface IQuiz
    {
        public int Position { get; }
        public int LowerLimitPosition { get; }
        public int UpperLimitPosition { get; }
        public string Question { get; }
        public IEnumerable<string> Answers { get; }
        public bool IsSeveralCorrectAnswers { get; }

        public void NextPosition();
        public void SetAnswer(List<string> answers);
        public ResultItem FinishQuiz();
    }
}
