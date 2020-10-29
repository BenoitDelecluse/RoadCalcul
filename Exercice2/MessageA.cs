using Exercice2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    public class MessageA : MessageBase
    {
        public void MyCustomeMethod()
        {
            Console.WriteLine("MyCustomeMethod A");
        }
    }
}
