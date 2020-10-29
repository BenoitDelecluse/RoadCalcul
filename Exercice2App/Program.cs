using Exercice2.Interfaces;
using Exercice2;
using System;
using Exercice2App.Model.Interfaces;

namespace Exercice2App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercice 2 Console App");
            var messageA = new MessageA();
            messageA.MyCustomeMethod();
            var messageB = new MessageB();
            messageB.MyCustomeMethod();
            var messageC = new MessageC();
            messageC.MyCustomeMethod();

            Console.WriteLine("...");
            UseMyCustomMethod(messageA);
            UseMyCustomMethod(messageB);
            UseMyCustomMethod(messageC);
        }

        public static void UseMyCustomMethod(MessageBase CurrMessage)
        {
            CurrMessage.MyCustomeMethod();
        }
    }
}
