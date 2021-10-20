using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Exceptions
{
    public class QuizAlreadyEndedException: ApplicationException
    {
        public QuizAlreadyEndedException() : base("Quiz has alreasy ended") { }
    }
}
