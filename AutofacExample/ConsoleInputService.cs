using System;

namespace AutofacExample
{
    public class ConsoleInputService
    {
        private string input = "input-initializer";

        public string GetInput()
        {
            input = Console.ReadLine();
            return input;
        }

        public bool ExitWasRequested()
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
