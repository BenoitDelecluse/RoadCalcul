using Exercice2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2App.Model.Interfaces
{
    public class MessageBase : IMessageBase
    {
        public virtual void MyCustomeMethod()
        {
            Console.WriteLine("MyCustomeMethod Base");
        }
    }
}
