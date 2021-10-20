using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Exceptions
{
    public class InvalidUserPasswordException : ApplicationException
    {
        public InvalidUserPasswordException(): base("invalid user password")
        {
        }
    }
}
