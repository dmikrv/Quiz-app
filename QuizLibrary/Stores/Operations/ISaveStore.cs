using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Stores.Operations
{
    public interface ISaveStore : ISaveResultStore, ISaveAccountStore, ISaveQuizStore { }
}
