using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Account
{
    public class Authorizer
    {
        public string Login { get; private set; }
        
        internal Authorizer(string login)
        {
            Login = login;
        }
    }
}
