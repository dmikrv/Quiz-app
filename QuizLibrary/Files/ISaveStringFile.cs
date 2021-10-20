using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Files
{
    public interface ISaveStringFile
    {
        public void Write(string pathToFile, string content);
    }
}
