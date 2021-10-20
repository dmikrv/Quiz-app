using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using QuizLibrary.Entities;
using QuizLibrary.Stores.Operations;

namespace QuizLibrary.Stores
{
    [Serializable]
    public class AccountStore
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        [JsonIgnore]
        public ISaveAccountStore Saver { get; set; }

        public void Add(Account account)
        {
            if (Accounts.Contains(account))
                throw new Exception("account with the login already has");
            Accounts.Add(account);
            Save();
        }

        public void Save()
        {
            Saver?.SaveAccountStore(this);
        }
    }
}
