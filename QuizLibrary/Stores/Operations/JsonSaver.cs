using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

using QuizLibrary.Files;

namespace QuizLibrary.Stores.Operations
{
    public class JsonSaver : ISaveStore
    {
        private string _filename;

        ISaveStringFile write = new WriteStringFile();
        JsonSerializerOptions options = new JsonSerializerOptions 
        { 
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        };

        public JsonSaver(string filename)
        {
            _filename = filename;
        }

        public void SaveAccountStore(AccountStore store)
        {
            
            var json = JsonSerializer.Serialize<AccountStore>(store, options);
            write.Write(_filename + ".json", json);
        }

        public void SaveQuizStore(QuizStore store)
        {
            var json = JsonSerializer.Serialize<QuizStore>(store, options);
            write.Write(_filename + ".json", json);
        }

        public void SaveResultStore(ResultStore store)
        {
            var json = JsonSerializer.Serialize<ResultStore>(store, options);
            write.Write(_filename + ".json", json);
        }
    }
}
