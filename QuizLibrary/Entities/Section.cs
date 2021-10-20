using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Entities
{
    [Serializable]
    public class Section
    {
        public Section()
        {
        }

        public Section(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
