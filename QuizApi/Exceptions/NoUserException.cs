using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Exceptions
{
    public class NoUserException : ApplicationException
    {
        public NoUserException() : base("no such user in the database")
        {
        }
    }
}
