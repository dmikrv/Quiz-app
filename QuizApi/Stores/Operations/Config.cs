using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Stores.Operations
{
    internal class Config
    {
        internal string QuizStoreFilename { get; } = "quiz";
        internal string AccountStoreFilename { get; } = "accounts";
        internal string ResultStoreFilename { get; } = "results";
    }
}
