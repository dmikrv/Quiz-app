using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Files
{
    public interface ILoadStringFile
    {
        public string Read(string pathToFile);
    }
}
