using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Entities
{
    [Serializable]
    public class Answer
    {
        public Answer(string text, bool isCorrectAnswer)
        {
            Text = text;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public string Text { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
