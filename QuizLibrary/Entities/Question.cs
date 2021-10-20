using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Entities
{
    [Serializable]
    public class Question
    {
        public Question()
        {
        }

        public Question(string text, bool isSeveralCorrectAnswers)
        {
            Text = text;
            IsSeveralCorrectAnswers = isSeveralCorrectAnswers;
        }

        public string Text { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public bool IsSeveralCorrectAnswers { get; set; }
    }
}
