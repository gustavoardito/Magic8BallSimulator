using System;
using System.IO;

namespace AutofacExampleTests
{
    public class ConsoleInputMock
    {
        private StringReader consoleInputReader;

        // sets up the Console with a given input string
        public void GivenConsoleInputOf(string consoleInput)
        {
            if (consoleInputReader != null)
            {
                CloseConsoleInput();
            }

            consoleInputReader = new StringReader(consoleInput);
            Console.SetIn(consoleInputReader);
        }

        public void CloseConsoleInput()
        {
            consoleInputReader.Close();
            consoleInputReader.Dispose();
            consoleInputReader = null;
        }
    }
}
