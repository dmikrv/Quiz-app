using System;
using System.Collections.Generic;
using System.Text;
using QuizLibrary.Stores;
using QuizLibrary.Stores.Operations;

namespace QuizApi.Stores.Operations
{
    public class JsonMultiSaver : ISaveStore
    {
        public void SaveAccountStore(AccountStore store)
        {
            throw new NotImplementedException();
        }

        public void SaveQuizStore(QuizStore store)
        {
            throw new NotImplementedException();
        }

        public void SaveResultStore(ResultStore store)
        {
            throw new NotImplementedException();
        }
    }
}
