using ECBSample.Interfaces;
using System;


namespace ECBSample
{
    public class Boundary : IBoundary
    {
        public delegate string AskDelegate(string q);
        public delegate string DisplayDelegate(string q);

        public void Run()
        {
            var a = new AskDelegate(Ask);
            var d = new DisplayDelegate(Ask);

            var controller = new BankController(a, d);
            controller.CallCommand("Deposit");
            controller.CallCommand("GetBalance");
        }

        public string Ask(string question)
        {
            Console.WriteLine(question);
            var name = Console.ReadLine();
            return name;
        }

        public void Display(string text)
        {
            Console.WriteLine(text);
        }

    }
}
