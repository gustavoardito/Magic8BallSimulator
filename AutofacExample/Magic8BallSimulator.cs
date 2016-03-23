namespace AutofacExample
{
    public class Magic8BallSimulator
    {
        // our "dependencies" are now interfaces
        private IMessageService _messageService;
        private IInputService _inputService;
        private IOutputService _outputService;

        // we're now injecting Interfaces, this loosens our coupling to our "injected" dependencies
        public Magic8BallSimulator(IMessageService messageService, IInputService inputService,
         IOutputService outputService)
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
