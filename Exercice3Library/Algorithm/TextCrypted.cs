using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3Library.Algorithm
{
    public class TextCrypted : ITextCrypted
    {
        public string Crypte(string value)
        {
            return Reverse(value);
        }

        public string Uncrypte(string value)
        {
            return Reverse(value);
        }

        private string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
    }
}
