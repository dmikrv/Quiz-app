using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using QuizLibrary.Security;

namespace QuizLibrary.Entities
{
    [Serializable]
    public class Account
    {
        public Account()
        {
        }

        public Account(string login, string passwordHash, DateTime birthday)
        {
            Login = login;
            Password = passwordHash;
            Birthday = birthday;
        }
        
        public string Login { get; set; }
        [JsonInclude]
        public string Password { get; set; }

        public DateTime Birthday { get; set; }
    }
}
