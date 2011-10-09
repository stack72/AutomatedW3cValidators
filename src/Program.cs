using Autofac;
using AutomatedW3cValidator.Validators;
using Util.ConfigManager;

namespace AutomatedW3cValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var container = Bootstrap.Components())
            {
                XhtmlValidation(container, "www.google.com");
                CssValidation(container, "www.google.com");
            }

        }

        private static void CssValidation(IContainer container, string url)
        {
            var cssValidator = container.Resolve<ICssValidator>();
            cssValidator.Url = url;
            cssValidator.Validate();
        }

        private static void XhtmlValidation(IContainer container, string url)
        {
            var xhtmlValidator = container.Resolve<IXhtmlValidator>();
            xhtmlValidator.Url = url;
            xhtmlValidator.Validate();
        }
    }
}
