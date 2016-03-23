using System.IO;

using Autofac;

using AutofacExample.Services;

namespace AutofacExample.Config
{
    public class ContainerSetup
    {
        private ContainerBuilder builder;

        public Config _config { get; set; }

        public IContainer BuildContainer()
        {
            builder = new ContainerBuilder();

            // in English this reads, setup ConsoleInputService as the implementation of 
            // IInputService
            builder.RegisterType<ConsoleInputService>().As<IInputService>();

            // Magic8BallSimulator doesn't implement an interface, its registered as-is
            builder.RegisterType<Magic8BallSimulator>();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<ConsoleOutputService>().As<IOutputService>();

            return builder.Build();
        }

        public IContainer BuildContainer(Config config)
        {
            _config = config;
            
            // snip - previous code is still valid
            // we're now registering our IOutputService based on our pass config configuration class
            if (_config.OutputModes.Contains(OutputModes.Console) || _config.OutputModes.Contains(OutputModes.All))
            {
                builder.RegisterType<ConsoleOutputService>().As<IOutputService>();
            }

            if (_config.OutputModes.Contains(OutputModes.Popup) || _config.OutputModes.Contains(OutputModes.All))
            {
                builder.RegisterType<PopupOutputService>().As<IOutputService>();
            }

            if (_config.OutputModes.Contains(OutputModes.File) || _config.OutputModes.Contains(OutputModes.All))
            {
                string outputFilePath = Path.Combine(Path.GetTempPath(), "magic8BallOutput.txt");
                builder.Register(c => new FileOutputService(outputFilePath)).As<IOutputService>();
            }

            return builder.Build();
        }
    }
}
