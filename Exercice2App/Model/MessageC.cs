using Exercice2.Interfaces;
using Exercice2App.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2
{
    public class MessageC : MessageBase
    {
        public override void MyCustomeMethod()
        {
            Console.WriteLine("MyCustomeMethod C");
        }
    }
}
