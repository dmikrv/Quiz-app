using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Entities
{
    public class Result
    {
        public Result() { }

        public Result(string accountLogin, string sectionName, int? quizId, int numberCorrectAnswer)
        {
            AccountLogin = accountLogin;
            SectionName = sectionName;
            QuizId = quizId;
            NumberCorrectAnswer = numberCorrectAnswer;
        }

        public string AccountLogin { get; set; }
        public string SectionName { get; set; }
        public int? QuizId { get; set; }
        public int NumberCorrectAnswer { get; set; }
    }
}
