namespace AutofacExample
{
    using System.IO;

    using Autofac;

    public class ContainerSetup
    {
        private ContainerBuilder builder;

        public IContainer BuildContainer()
        {
            builder = new ContainerBuilder();

            // in English this reads, setup ConsoleInputService as the implementation of 
            // IInputService
            builder.RegisterType<ConsoleInputService>().As<IInputService>();

            // Magic8BallSimulator doesn't implement an interface, its registered as-is
            builder.RegisterType<Magic8BallSimulator>();
            builder.RegisterType<MessageService>().As<IMessageService>();

            // builder.RegisterType<ConsoleOutputService>().As<IOutputService>();
            string outputFilePath = Path.Combine(Path.GetTempPath(), "magic8BallOutput.txt");
            builder.Register(c => new MultipleOutputService(outputFilePath)).As<IOutputService>();

            return builder.Build();
        }
    }
}
