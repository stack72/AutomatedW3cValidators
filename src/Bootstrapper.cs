using Autofac;
using Util.ConfigManager;

namespace AutomatedW3cValidator
{
    public class Bootstrap
    {
        public static IContainer Components()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ConfigManager()).As<IConfigManager>();
            
            return builder.Build();
        }
    }
}
