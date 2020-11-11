using Exercice3Library.Algorithm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercice3Library
{
    public class JsonFile
    {
        public string ReadJsonFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                var st = System.IO.File.ReadAllText(path);
                try 
                {
                    var result = JsonConvert.DeserializeObject(st);
                }
                catch(Exception ex)
                {
                    throw new Exception(path + " is not a json file" + ex.Message);
                }
                return st;
            }
            throw new Exception("File does not exist");
        }

        public String ReadCryptedJsonlFile(string path, ITextCrypted Algo)
        {
            if (System.IO.File.Exists(path))
            {
                var cryptedValue = System.IO.File.ReadAllText(path);
                var uncrypted = Algo.Uncrypte(cryptedValue);
                try
                {
                    var result = JsonConvert.DeserializeObject(uncrypted);
                }
                catch (Exception ex)
                {
                    throw new Exception(path + " is not a json file" + ex.Message);
                }
                return uncrypted;
            }
            throw new Exception("File does not exist");
        }

        private String handleJason(string value, ITextCrypted Algo)
        {
            return value;
        }
    }
}
