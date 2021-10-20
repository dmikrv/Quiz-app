using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using System.Security.Cryptography;

namespace QuizLibrary.Security
{
    [Serializable]
    public class Hash
    {
        [JsonInclude]
        public string HashString { get; set; }

        public Hash(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = Encoding.Unicode.GetBytes(str);
                var hashBytes = sha256.ComputeHash(bytes);

                foreach (byte x in hashBytes)
                {
                    HashString += String.Format("{0:x2}", x);
                }
            }
        }

        public override string ToString()
        {

            return HashString;
        }

        public override int GetHashCode()
        {
            return HashString.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return HashString.ToString() == obj.ToString();
        }
    }
}
