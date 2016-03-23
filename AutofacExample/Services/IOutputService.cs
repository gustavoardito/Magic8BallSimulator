
namespace AutofacExample.Services
{
    public interface IOutputService
    {
        void PrintExit();

        void PrintInputPrompt();

        void PrintMessage(string message);

        void PrintWelcome();
    }
}
