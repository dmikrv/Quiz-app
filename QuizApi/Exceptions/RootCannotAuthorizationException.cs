using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Exceptions
{
    public class RootCannotAuthorizationException: ApplicationException
    {
        public RootCannotAuthorizationException() : base("root cannot authorization in program") 
        {

        }
    }
}
