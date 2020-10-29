using Exercice3Library.Algorithm;
using System;

namespace Exercice3Library
{
    public class TxtFile
    {
        public string ReadTxtFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllText(path);
            }
            throw new Exception("File does not exist");

        }

        public string ReadEncryptedTextFile(string path , ITextCrypted Algo)
        {
            var cryptedValue = ReadTxtFile(path);
            return Algo.Uncrypte(cryptedValue); 
        }
    }
}
