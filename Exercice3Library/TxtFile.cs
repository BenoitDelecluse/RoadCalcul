using Exercice3Library.Algorithm;
using System;

namespace Exercice3Library
{
    public class TxtFile
    {
        private Security.SecurityContext Role;
        public TxtFile(Security.SecurityContext role)
        {
            Role = role;
        }
        public string ReadTxtFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                if (this.Role.CheckRolesForFile(path))
                {
                    return System.IO.File.ReadAllText(path);

                }
                throw new Exception("Access to the file : " + path + "  is disabled due to role restriction.");
            }
            throw new Exception("File does not exist");
        }

        public string ReadCryptedTextFile(string path, ITextCrypted Algo)
        {
            var cryptedValue = ReadTxtFile(path);
            return Algo.Uncrypte(cryptedValue);
        }
    }
}
