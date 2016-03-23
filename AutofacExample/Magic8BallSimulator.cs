using System.Collections.Generic;

using AutofacExample.Services;

namespace AutofacExample
{
    public class Magic8BallSimulator
    {
        // our "dependencies" are now interfaces
        private IMessageService _messageService;
        private IInputService _inputService;
        private IEnumerable<IOutputService> _outputServices;

        // we're now injecting Interfaces, this loosens our coupling to our "injected" dependencies
        public Magic8BallSimulator(IMessageService messageService, IInputService inputService,
         IEnumerable<IOutputService> outputServices)
        {
            _messageService = messageService;
            _inputService = inputService;
            _outputServices = outputServices;
        }

        public void Run()
        {
            PrintWelcome();
            string message = string.Empty;
            PrintInputPrompt();
            _inputService.GetInput();

            while (!_inputService.ExitWasRequested())
            {
                message = _messageService.GetMessage();

                PrintMessage(message);
                PrintInputPrompt();
                _inputService.GetInput();
            }

            PrintExit();
        }

        private void PrintWelcome()
        {
            foreach (IOutputService outputService in _outputServices)
            {
                outputService.PrintWelcome();
            }
        }

        private void PrintInputPrompt()
        {
            foreach (IOutputService outputService in _outputServices)
            {
                outputService.PrintInputPrompt();
            }
        }

        private void PrintMessage(string message)
        {
            foreach (IOutputService outputService in _outputServices)
            {
                outputService.PrintMessage(message);
            }
        }

        private void PrintExit()
        {
            foreach (IOutputService outputService in _outputServices)
            {
                outputService.PrintExit();
            }
        }
    }
}
