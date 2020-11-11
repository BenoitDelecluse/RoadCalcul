using Exercice3Library.Algorithm;
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
            if (System.IO.File.Exists(path))
            {
                if (this.Role.CheckRolesForFile(path))
                {

                    XmlDocument xmldoc = new XmlDocument();
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    xmldoc.Load(fs);
                    return xmldoc;

                }
                throw new Exception("Access to the file : " + path + "  is disabled due to role restriction.");
            }
            throw new Exception("File does not exist path :" + path);
        }

        public XmlDocument ReadCryptedXmlFile(string path, ITextCrypted Algo)
        {
            var cryptedDoc = ReadXmlFile(path);
            var contentnode = cryptedDoc.DocumentElement;
            handleNode(contentnode, Algo);
            return cryptedDoc;
        }

        private static void handleNode(XmlNode node, ITextCrypted Algo)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    handleNode(child, Algo);
                }
            }
            else
            {
                node.InnerText = Algo.Uncrypte(node.InnerText);
            }
        }
    }
}
