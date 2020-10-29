using Exercice3Library.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Exercice3Library
{
    public class XmlFile
    {
        private Security.SecurityContext Role;
        public XmlFile(Security.SecurityContext role)
        {
            Role = role;
        }
        public XmlDocument ReadXmlFile(string path)
        {
            if (this.Role.CheckRolesForFile(path))
            {
                if (System.IO.File.Exists(path))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    xmldoc.Load(fs);
                    return xmldoc;
                }
                throw new Exception("File does not exist path :" + path);
            }
            throw new Exception("Access to the file : " + path + "  is disabled due to role restriction.");
        }
    }
}
