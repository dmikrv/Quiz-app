using System;
using System.Collections.Generic;
using System.Text;
using QuizLibrary.Stores;
using QuizLibrary.Stores.Operations;

namespace QuizApi.Stores.Operations
{
    public class JsonMultiLoader : ILoadStore
    {
        public AccountStore LoadAccountStore()
        {
            throw new NotImplementedException();
        }

        public QuizStore LoadQuizStore()
        {
            throw new NotImplementedException();
        }

        public ResultStore LoadResultStore()
        {
            throw new NotImplementedException();
        }
    }
}
