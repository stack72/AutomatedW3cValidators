using Autofac;
using AutomatedW3cValidator.Validators;
using Util.ConfigManager;

namespace AutomatedW3cValidator
{
    public class Bootstrap
    {
        public static IContainer Components()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ConfigManager()).As<IConfigManager>();

            builder.Register<IValidator>(
                c => new Validator(
                    c.Resolve<IConfigManager>())
                    );

            return builder.Build();
        }
    }
}
