using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using QuizLibrary.Entities;
using QuizLibrary.Stores.Operations;

namespace QuizLibrary.Stores
{
    [Serializable]
    public class ResultStore
    {
        public List<Result> Results { get; set; } = new List<Result>();
        [JsonIgnore]
        public ISaveResultStore Saver { get; set; }

        public void Add(Result result)
        {
            Results.Add(result);
            Save();
        }

        public void Save()
        {
            Saver?.SaveResultStore(this);
        }
    }
}
