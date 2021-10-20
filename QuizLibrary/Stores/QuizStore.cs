using System;
using System.Collections.Generic;
using System.Text;

using QuizLibrary.Entities;
using QuizLibrary.Stores.Operations;
using System.Text.Json.Serialization;

namespace QuizLibrary.Stores
{
    [Serializable]
    public class QuizStore
    {
        public List<Quiz> Quiz { get; set; } = new List<Quiz>();
        [JsonIgnore]
        public ISaveQuizStore Saver { get; set; }

        public void Add(Quiz quiz)
        {
            Quiz.Add(quiz);
            Save();
        }

        public void Save()
        {
            Saver?.SaveQuizStore(this);
        }
    }
}
