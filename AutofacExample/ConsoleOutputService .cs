using System;

namespace AutofacExample
{
    public class ConsoleOutputService : IOutputService
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Magic 8 Ball simulator");
        }

        public void PrintInputPrompt()
        {
            Console.Write("Ask a Question, or press [Enter] to exit >> ");
        }

        public void PrintExit()
        {
            Console.WriteLine("Goodbye");
        }
    }
}
