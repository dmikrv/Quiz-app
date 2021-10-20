using System;
using System.Collections.Generic;
using System.IO;

namespace QuizLibrary.Files
{
    public class ReadStringFile : ILoadStringFile
    {
        public string Read(string pathToFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
