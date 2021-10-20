using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Entities
{
    [Serializable]
    public class Quiz
    {
        public Quiz()
        {
            Id = IdInc++;
        }

        public Quiz(string name, string authorLogin)
        {
            Id = IdInc++;
            Name = name;
            AuthorLogin = authorLogin;
        }

        public static int IdInc { get; set; } = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string AuthorLogin { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
