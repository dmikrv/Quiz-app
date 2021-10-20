using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Exceptions
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public UserAlreadyExistsException(): base("such user already exists")
        {
        }
    }
}
