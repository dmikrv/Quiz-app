using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace QuizLibrary.Files
{
    public class WriteStringFile : ISaveStringFile
    {
        public void Write(string pathToFile, string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToFile, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(content);
                }
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
}
    }
}
