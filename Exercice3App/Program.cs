using Exercice3Library;
using Exercice3Library.Algorithm;
using Exercice3Library.Security;
using System;
using System.Collections.Generic;

namespace Exercice3App
{
    class Program
    {
        static SecurityContext SecurityContextAdmin = new SecurityContext(Roletype.Admin, null);
        static SecurityContext SecurityContextOther = new SecurityContext(Roletype.Other, new List<string> { "NormalTxtFile.txt", "CryptedTxtFile.txt", "NormalXMLFile.xml", "CryptedXMLFile.xml", "NormaljsonFile.json" , "CryptedjsonFile.json" });
        static TxtFile TxtReaderAdmin;
        static TxtFile TxtReaderOther;
        static XmlFile XmlReaderAdmin;
        static XmlFile XmlReaderOther;
        static JsonFile JsonReaderAdmin;
        static JsonFile JsonReaderOther;
        static TextCrypted AlgoR;

        static int Filetype;
        static int CrtyptedType;
        static int RightType;
        static string RightValue;
        static string FileName;


        static void Main(string[] args)
        {
            TxtReaderAdmin = new TxtFile(Program.SecurityContextAdmin);
            TxtReaderOther = new TxtFile(SecurityContextOther);
            XmlReaderAdmin = new XmlFile(SecurityContextAdmin);
            XmlReaderOther = new XmlFile(SecurityContextOther);
            JsonReaderAdmin = new JsonFile(SecurityContextAdmin);
            JsonReaderOther = new JsonFile(SecurityContextOther);
            AlgoR = new TextCrypted();
            Process();
        }

        static void Process()
        {
            if (ReadInput())
            {
                switch (Filetype)
                {
                    case 1:
                        if (CrtyptedType == 1)
                        {
                            processTxtCrypted();
                        }
                        else
                        {
                            processTxt();
                        }
                        break;
                    case 2:
                        if (CrtyptedType == 1)
                        {
                            processXmlCrypted();
                        }
                        else
                        {
                            processXml();
                        }
                        break;
                    case 3:
                        if (CrtyptedType == 1)
                        {
                            processJsonCrypted();
                        }
                        else
                        {
                            processJson();
                        }
                        break;
                    default:
                        // code block
                        break;
                }
            }
            Console.WriteLine("press <Enter> to restart another key to exit");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Process();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void processTxt()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("TxtReaderAdmin with Admin Right");
                        Console.WriteLine(TxtReaderAdmin.ReadTxtFile(FileName));
                    }
                    else
                    {
                        Console.WriteLine("TxtReaderOther with Right Other");
                        Console.WriteLine(TxtReaderOther.ReadTxtFile(FileName));
                    }
                }
                else
                {
                    Console.WriteLine("TxtReaderOther with no Right");
                    Console.WriteLine(TxtReaderOther.ReadTxtFile(FileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        static void processTxtCrypted()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("TxtReaderAdmin crypted with Admin Right");
                        Console.WriteLine(TxtReaderAdmin.ReadCryptedTextFile(FileName, AlgoR));
                    }
                    else
                    {
                        Console.WriteLine("TxtReaderOther crypted with Right Other");
                        Console.WriteLine(TxtReaderOther.ReadCryptedTextFile(FileName, AlgoR));
                    }
                }
                else
                {
                    Console.WriteLine("TxtReaderOther crypted with no Right");
                    Console.WriteLine(TxtReaderOther.ReadCryptedTextFile(FileName, AlgoR));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void processXml()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("XmlReaderAdmin with Admin Right");
                        Console.WriteLine(XmlReaderAdmin.ReadXmlFile(FileName)?.InnerXml);
                    }
                    else
                    {
                        Console.WriteLine("XmlReaderOther with Right Other");
                        Console.WriteLine(XmlReaderOther.ReadXmlFile(FileName)?.InnerXml);
                    }
                }
                else
                {
                    Console.WriteLine("XmlReaderOther with no Right");
                    Console.WriteLine(XmlReaderOther.ReadXmlFile(FileName)?.InnerXml);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void processXmlCrypted()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("XmlReaderAdmin crypted with Admin Right");
                        Console.WriteLine(XmlReaderAdmin.ReadCryptedXmlFile(FileName, AlgoR)?.InnerXml);
                    }
                    else
                    {
                        Console.WriteLine("XmlReaderOther crypted with Right Other");
                        Console.WriteLine(XmlReaderOther.ReadCryptedXmlFile(FileName, AlgoR)?.InnerXml);
                    }
                }
                else
                {
                    Console.WriteLine("XmlReaderOther crypted with no Right");
                    Console.WriteLine(XmlReaderOther.ReadCryptedXmlFile(FileName, AlgoR)?.InnerXml);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void processJson()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("JsonReaderAdmin with Admin Right");
                        Console.WriteLine(JsonReaderAdmin.ReadJsonFile(FileName));
                    }
                    else
                    {
                        Console.WriteLine("JsonReaderOther with Right Other");
                        Console.WriteLine(JsonReaderOther.ReadJsonFile(FileName));
                    }
                }
                else
                {
                    Console.WriteLine("JsonReaderOther with no Right");
                    Console.WriteLine(JsonReaderOther.ReadJsonFile(FileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void processJsonCrypted()
        {
            try
            {
                if (RightType == 1)
                {
                    if (RightValue == "Admin")
                    {
                        Console.WriteLine("JsonReaderAdmin crypted with Admin Right");
                        Console.WriteLine(JsonReaderAdmin.ReadCryptedJsonlFile(FileName, AlgoR));
                    }
                    else
                    {
                        Console.WriteLine("JsonReaderOther crypted with Right Other");
                        Console.WriteLine(JsonReaderOther.ReadCryptedJsonlFile(FileName, AlgoR));
                    }
                }
                else
                {
                    Console.WriteLine("JsonReaderOther crypted with no Right");
                    Console.WriteLine(JsonReaderOther.ReadCryptedJsonlFile(FileName, AlgoR));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static Boolean ReadInput()
        {
            Console.WriteLine("Choose File Type:");
            Console.WriteLine("1 : Text File");
            Console.WriteLine("2 : Xml File");
            Console.WriteLine("3: Json File");
            Console.WriteLine("Enter the corresponding number");
            Filetype = ValidateValue(Console.ReadLine(), 3);
            if (Filetype != -1)
            {
                Console.WriteLine("Crypted File:");
                Console.WriteLine("1 : Yes");
                Console.WriteLine("2 : No");
                Console.WriteLine("Enter the corresponding number");
                CrtyptedType = ValidateValue(Console.ReadLine(), 2);
                if (CrtyptedType != -1)
                {
                    Console.WriteLine("Role Security:");
                    Console.WriteLine("1 : Yes");
                    Console.WriteLine("2 : No");
                    Console.WriteLine("Enter the corresponding number");
                    RightType = ValidateValue(Console.ReadLine(), 2);
                    if (RightType != -1)
                    {
                        if (RightType == 1)
                        {
                            Console.WriteLine("Enter Role security :");
                            RightValue = Console.ReadLine();
                        }
                        Console.WriteLine("Enter File name :");
                        FileName = Console.ReadLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Errors input valuer");
                    }
                }
                else
                {
                    Console.WriteLine("Errors input valuer");
                }
            }
            else
            {
                Console.WriteLine("Errors input valuer");
            }
            return false;
        }

        static int ValidateValue(string value, int MaxValue)
        {
            var resultvalue = -1;
            var result = int.TryParse(value, out resultvalue);
            if (resultvalue <= MaxValue && resultvalue > 0)
            {
                return resultvalue;
            }
            return -1;
        }

    }


}
