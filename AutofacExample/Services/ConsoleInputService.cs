using System;

namespace AutofacExample.Services
{
    public class ConsoleInputService : IInputService
    {
        private string input = "input-initializer";

        public string GetInput()
        {
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                input = input.Trim();
            }

            return input;
        }

        public bool ExitWasRequested()
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
