using Autofac;

namespace AutofacExample
{
    public class SimulationRunner
    {
        public static void Main(string[] args)
        {
            ContainerSetup containerSetup = new ContainerSetup();
            IContainer container = containerSetup.BuildContainer();
            container.Resolve<Magic8BallSimulator>().Run();
        }
    }
}
