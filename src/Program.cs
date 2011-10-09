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
                throw new ArgumentNullException("Url", "You need to pass a URL to the validator");

            using (var container = Bootstrap.Components())
            {
                var url = args[0];
                Validation(container, url, ValidatorType.XHTML);
                Validation(container, url, ValidatorType.CSS);
            }
        }

        private static void Validation(IContainer container, string url, ValidatorType validatorType)
        {
            var validator = container.Resolve<IValidator>();
            validator.Url = url;
            validator.ValidatorType = validatorType;
            validator.Validate();
        }
    }
}
