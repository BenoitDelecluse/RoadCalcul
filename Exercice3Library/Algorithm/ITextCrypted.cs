using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3Library.Algorithm
{
    public interface ITextCrypted
    {
        public string Uncrypte(string value);
        public string Crypte(string value);
    }
}
