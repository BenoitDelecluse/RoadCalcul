using System;

namespace Exercice3Library
{
    public class TxtFile
    {
        public string ReadTxtFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
            }
            throw new Exception("File does not exist");

        }
    }
}
