using System;

using AutofacExample.Services;

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
    }
}
