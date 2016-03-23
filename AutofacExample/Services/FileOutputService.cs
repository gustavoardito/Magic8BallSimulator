using System.IO;

namespace AutofacExample.Services
{
    public class FileOutputService : IOutputService
    {
        private string _outputFilePath = string.Empty;

        private string _message = string.Empty;

        public FileOutputService(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        public void PrintExit()
        {
        }

        public void PrintInputPrompt()
        {
        }

        public void PrintMessage(string message)
        {
            _message = message;
            File.AppendAllText(_outputFilePath, _message);
        }

        public void PrintWelcome()
        {
        }
    }
}
