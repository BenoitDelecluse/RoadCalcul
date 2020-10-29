using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Exercice3Library
{
    public class XmlFile
    {
        public XmlDocument ReadXmlFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                XmlDocument xmldoc = new XmlDocument();
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
            }
            throw new Exception("File does not exist");
        }
    }
}
