using System;
using System.Collections.Generic;
using System.Text;

using QuizLibrary.Stores.Operations;
using QuizLibrary.Entities;
using QuizLibrary.Security;

namespace QuizLibrary.Stores
{
    public class GeneralStore
    {
        public GeneralStore()
        {
        }

        public GeneralStore(ILoadStore loader)
        {
            Loader = loader;
        }

        public ResultStore ResultStore_ { get; set; }
        public AccountStore AccountStore_ { get; set; }
        public QuizStore QuizStore_ { get; set; }

        public ILoadStore Loader { get; set; }


    }
}
