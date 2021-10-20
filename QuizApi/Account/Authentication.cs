using System;
using System.Collections.Generic;
using System.Text;

using QuizApi;
using QuizLibrary.Entities;
using QuizLibrary.Security;
using QuizApi.Exceptions;

using System.Linq;

namespace QuizApi.Account
{
    public class Authentication
    {
        Store store = new Store();

        /// <exception cref = "NoUserException" ></exception>
        /// <exception cref = "InvalidUserPasswordException" ></exception>
        /// <exception cref = "RootCannotAuthorizationException" ></exception>
        public Authorizer Authenticate(string login, string password)
        {
            login = login.ToLower().Trim();

            if (login == "root")
                throw new RootCannotAuthorizationException();

            var query = from account in store.Instance.AccountStore_.Accounts
                        where account.Login.ToLower() == login
                        select account;

            if (query.Count() == 0)
                throw new NoUserException();

            if (query.First().Password == new Hash(password).HashString)
                return new Authorizer(login);
            throw new InvalidUserPasswordException();
        }
    }
}
