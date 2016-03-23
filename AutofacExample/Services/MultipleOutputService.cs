using System;
using System.IO;
using System.Windows.Forms;

namespace AutofacExample.Services
{
    public class MultipleOutputService : IOutputService
    {
        private string _outputFilePath = String.Empty;

        public MultipleOutputService(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        private string _message = string.Empty;

        public void PrintMessage(string message)
        {
            _message = message;
            WriteMessageToConsole();
            WriteMessageToFile();
            ShowMessagePopup();
        }

        private void WriteMessageToConsole()
        {
            Console.WriteLine(_message);
        }

        private void WriteMessageToFile()
        {
            File.AppendAllText(_outputFilePath, _message);
        }

        // because they're not enough popups in our lives :)
        private void ShowMessagePopup()
        {
            MessageBox.Show(_message, "The 8-Ball says");
        }

        public void PrintExit()
        {
            //throw new NotImplementedException();
        }

        public void PrintInputPrompt()
        {
            //throw new NotImplementedException();
        }

        public void PrintWelcome()
        {
            //throw new NotImplementedException();
        }
    }
}
