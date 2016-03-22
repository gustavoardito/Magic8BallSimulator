using System;
using System.Collections.Generic;

namespace AutofacExample
{
    /// <summary>
    /// </summary>
    public class Magic8BallSimulator
    {
        // these 3 classes are "dependencies" of this class, in that this class cannot
        // do its job without their services.
        private MessageService _messageService;
        private ConsoleInputService _inputService;
        private ConsoleOutputService _outputService;

        // here our dependencies are "injected" into this class, that's depedency injection, 
        // really that's it!
        public Magic8BallSimulator(MessageService messageService, ConsoleInputService inputService,
         ConsoleOutputService outputService)
        {
            _messageService = messageService;
            _inputService = inputService;
            _outputService = outputService;
        }

        public void Run()
        {
            _outputService.PrintWelcome();
            string message = string.Empty;

            _outputService.PrintInputPrompt();
            _inputService.GetInput();

            while (!_inputService.ExitWasRequested())
            {
                message = _messageService.GetMessage();
                _outputService.PrintMessage(message);
                _outputService.PrintInputPrompt();
                _inputService.GetInput();
            }

            _outputService.PrintExit();
        }
    }
}
