using System;
using System.Collections.Generic;
using System.Text;

using QuizLibrary.Entities;

namespace QuizApi
{
    public class ResultItem : Result
    {
        public ResultItem() { }

        public ResultItem(string accountLogin, string sectionName, int quizId, int numberCorrectAnswer) 
            : base(accountLogin, sectionName, quizId, numberCorrectAnswer)
        {
        }
    }
}
