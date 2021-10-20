using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Stores.Operations
{
    public interface ILoadStore
    {
        public ResultStore LoadResultStore();
        public AccountStore LoadAccountStore();
        public QuizStore LoadQuizStore();
    }
}
