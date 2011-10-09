using System;
using Autofac;
using AutomatedW3cValidator.Validators;
using Util.ConfigManager;

namespace AutomatedW3cValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoFacBootStrapper();

            var xhtmlValidator = new XhtmlValidator("www.google.com");
            xhtmlValidator.Validate();

            var cssValidator = new CssValidator("www.google.com");
            cssValidator.Validate();
        }

        private static void AutoFacBootStrapper()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new ConfigManager()).As<IConfigManager>();
            
        }
    }
}
