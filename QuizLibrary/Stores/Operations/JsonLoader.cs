using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

using QuizLibrary.Files;

namespace QuizLibrary.Stores.Operations
{
    public class JsonLoader : ILoadStore
    {
        private string _quizFilename;
        private string _accountFilename;
        private string _resultFilename;

        ILoadStringFile load = new ReadStringFile();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        };

        public JsonLoader(string quizFilename, string accountFilename, string resultFilename)
        {
            _quizFilename = quizFilename;
            _accountFilename = accountFilename;
            _resultFilename = resultFilename;
        }

        /// <returns>Can return null</returns>
        public AccountStore LoadAccountStore()
        {
            var json = load.Read(_accountFilename + ".json");
            if (json != null)
            {
                return JsonSerializer.Deserialize<AccountStore>(json, options); ;
            }
            return null;
        }

        /// <returns>Can return null</returns>
        public QuizStore LoadQuizStore()
        {
            var json = load.Read(_quizFilename + ".json");
            if (json != null)
            {
                var quizStore = JsonSerializer.Deserialize<QuizStore>(json, options);
                return quizStore;
            }
            return null;
        }

        /// <returns>Can return null</returns>
        public ResultStore LoadResultStore()
        {
            var json = load.Read(_resultFilename + ".json");
            if (json != null)
            {
                return JsonSerializer.Deserialize<ResultStore>(json, options);
            }
            return null;
        }
    }
}
