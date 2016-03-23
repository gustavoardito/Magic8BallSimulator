using System;

namespace AutofacExample.Services
{
    public class ConsoleInputService : IInputService
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
