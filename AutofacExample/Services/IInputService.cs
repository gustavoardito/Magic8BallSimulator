namespace AutofacExample.Services
{
    public interface IInputService
    {
        bool ExitWasRequested();

        string GetInput();
    }
}
