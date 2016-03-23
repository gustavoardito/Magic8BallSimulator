namespace AutofacExample
{
    public interface IInputService
    {
        bool ExitWasRequested();

        string GetInput();
    }
}
