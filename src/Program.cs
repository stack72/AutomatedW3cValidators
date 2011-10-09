using System;
using Autofac;
using AutomatedW3cValidator.Validators;

namespace AutomatedW3cValidator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (string.IsNullOrWhiteSpace(args[0]))
                throw new ArgumentNullException("You need to pass a URL to the validator");

            using (var container = Bootstrap.Components())
            {
                var url = args[0];
                XhtmlValidation(container, url);
                
                CssValidation(container, args[0]);
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
