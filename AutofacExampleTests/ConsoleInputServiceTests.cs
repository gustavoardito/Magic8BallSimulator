using System;
using System.Collections.Generic;

using AutofacExample;
using AutofacExample.Services;

using Moq;

using Xunit;

namespace AutofacExampleTests
{
    public class ConsoleInputServiceTests
    {
        private ConsoleInputMock consoleMock;

        public ConsoleInputServiceTests()
        {
            consoleMock = new ConsoleInputMock();
        }

        [Fact]
        public void ConsoleInputIsReturnedByGetInput()
        {
            string testInput = "This is test input.";
            consoleMock.GivenConsoleInputOf(testInput);

            ConsoleInputService service = new ConsoleInputService();
            string input = service.GetInput();
            consoleMock.CloseConsoleInput();

            Assert.Equal(testInput, input);
        }

        [Fact]
        public void ExitIsRequestedOnNewlineInput()
        {
            consoleMock.GivenConsoleInputOf(Environment.NewLine);

            ConsoleInputService service = new ConsoleInputService();
            service.GetInput();
            consoleMock.CloseConsoleInput();

            bool exitWasRequested = service.ExitWasRequested();
            Assert.True(exitWasRequested);
        }

        [Fact]
        public void ExitIsRequestedOnEmptyInput()
        {
            consoleMock.GivenConsoleInputOf(string.Empty);

            ConsoleInputService service = new ConsoleInputService();
            service.GetInput();
            consoleMock.CloseConsoleInput();

            bool exitWasRequested = service.ExitWasRequested();
            Assert.True(exitWasRequested);
        }

        [Fact]
        public void ExitIsRequestedOnWhitespaceInput()
        {
            consoleMock.GivenConsoleInputOf(" ");

            ConsoleInputService service = new ConsoleInputService();
            service.GetInput();
            consoleMock.CloseConsoleInput();

            bool exitWasRequested = service.ExitWasRequested();
            Assert.True(exitWasRequested);
        }

        [Fact]
        public void PrintExitIsCalledOnExitRequested()
        {
            // mocked IMessageService
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();

            // this is cool, we're getting a free mock of IInputService and we can specify
            // how the ExitWasRequested() method will behave by a lambda expression (as you
            // can see, it always returns true
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            // outservice mock
            var outputService = new Mock<IOutputService>();

            // setup and run our simulator
            var magic8BallSimulator = Magic8BallSimulatorSetup(messageService, inputService, outputService);

            magic8BallSimulator.Run();

            // a simple assertion *verifying* that the PrintExit() method was called
            outputService.Verify(s => s.PrintExit());
        }
        
        [Fact]
        public void GetMessageIsNotCalledAfterExitRequested()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();

            var magic8BallSimulator = Magic8BallSimulatorSetup(messageService, inputService, outputService);

            // verify that GetMessage() was *not* called
            messageService.Verify(s => s.GetMessage(), Times.Never());
        }

        [Fact]
        public void PrintWelcomeIsCalledOnRun()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();

            var magic8BallSimulator = Magic8BallSimulatorSetup(messageService, inputService, outputService);

            magic8BallSimulator.Run();
            outputService.Verify(s => s.PrintWelcome());
        }

        [Fact]
        public void PrintInputPromptIsCalledOnRun()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();

            var magic8BallSimulator = Magic8BallSimulatorSetup(messageService, inputService, outputService);

            magic8BallSimulator.Run();
            outputService.Verify(s => s.PrintInputPrompt());
        }

        private static Magic8BallSimulator Magic8BallSimulatorSetup(Mock<IMessageService> messageService, Mock<IInputService> inputService, Mock<IOutputService> outputService)
        {
            Magic8BallSimulator magic8BallSimulator = new Magic8BallSimulator(
                messageService.Object,
                inputService.Object,
                new List<IOutputService> { outputService.Object });
            return magic8BallSimulator;
        }
    }
}
