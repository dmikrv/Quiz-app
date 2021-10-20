using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

using QuizApi.Exceptions;
using QuizLibrary.Security;

namespace QuizApi.Account
{
    public class Registration
    {
        Store store = new Store();

        /// <exception cref = "UserAlreadyExistsException" ></exception>
        /// <exception cref = "FormatException" ></exception>
        public void Registry(string login, string password, DateTime birthday)
        {
            login = login.ToLower().Trim();
            if (CheckLogin(login))
                throw new UserAlreadyExistsException();

            Regex regLogin = new Regex("^[a-zA-Z_]{3,16}$");
            if (!regLogin.IsMatch(login))
                throw new FormatException("Login can only contain letters and underscore character in the range from 3 to 16");

            Regex regPass = new Regex("^[a-zA-Z0-9_@#$%]{6,24}$");
            if (!regPass.IsMatch(password))
                throw new FormatException("Password can only contain letters, numbers and underscore character, @, #, $, % in the range from 6 to 24");

            store.Instance.AccountStore_.Add(new QuizLibrary.Entities.Account(login, new Hash(password).HashString, birthday));
        }
        public bool CheckLogin(string login)
        {
            return (from account in store.Instance.AccountStore_.Accounts
                    where account.Login.ToLower() == login.ToLower()
                    select account).Count() == 1;
        }
    }
}
