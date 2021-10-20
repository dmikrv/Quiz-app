using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using QuizApi;
using QuizApi.Exceptions;
using QuizLibrary.Security;

namespace QuizApi.Account
{
    public class Edit
    {
        private string _login;

        Store store = new Store();

        public Edit(Authorizer authorizer)
        {
            if (authorizer == null)
                throw new Exception("invalid authorizer");
            _login = authorizer.Login;
        }

        /// <exception cref="InvalidUserPasswordException"></exception>
        public void EditPassword(string oldPass, string newPass)
        {
            var query = from account in store.Instance.AccountStore_.Accounts
                        where account.Login == _login
                        select account;

            var accountOld = new QuizLibrary.Entities.Account
            {
                Login = query.First().Login,
                Password = query.First().Password,
                Birthday = query.First().Birthday,
            };

            if (accountOld.Password != new Hash(oldPass).HashString)
                throw new InvalidUserPasswordException();
            store.Instance.AccountStore_.Accounts.Remove(query.First());

            Registration registration = new Registration();
            registration.Registry(accountOld.Login, newPass, accountOld.Birthday);
            
        }
        public void EditBirtday(DateTime newBirthday)
        {
            var query = from account in store.Instance.AccountStore_.Accounts
                        where account.Login == _login
                        select account;
            query.First().Birthday = newBirthday;
            store.Instance.AccountStore_.Save();
        }
    }
}
