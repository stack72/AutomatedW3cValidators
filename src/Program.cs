using System;
using System.Collections.Generic;
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

            var cmdLineArguments = ParseCommandLineArguements(args);

            using (var container = Bootstrap.Components())
            {
                string url = string.Empty;
                cmdLineArguments.TryGetValue("url", out url);

                string docType = string.Empty;
                cmdLineArguments.TryGetValue("docType", out docType);

                string validator = string.Empty;
                cmdLineArguments.TryGetValue("validatorType", out validator);
                ValidatorType validatorType = (ValidatorType)Enum.Parse(typeof(ValidatorType), validator);

                Validation(container, url, validatorType, docType);
            }
        }

        private static void Validation(IContainer container, string url, ValidatorType validatorType, string doctype)
        {
            var validator = container.Resolve<IValidator>();
            validator.Url = url;
            validator.DocumentType = doctype;
            validator.ValidatorType = validatorType;
            validator.Validate();
        }

        private static Dictionary<string, string> ParseCommandLineArguements(string[] args)
        {
            var commandLineArguements = new Dictionary<string, string>();
            foreach (var arg in args)
            {
                var key = arg.Substring(1, arg.IndexOf(":") - 1);
                var value = arg.Substring(arg.IndexOf(":") + 1, arg.Length - (arg.IndexOf(":") + 1));

                commandLineArguements.Add(key, value);
            }

            return commandLineArguements;

        }
    }
}
