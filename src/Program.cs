using System;
using AutomatedW3cValidator.Validators;

namespace AutomatedW3cValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var xhtmlValidator = new XhtmlValidator("www.google.com");
            xhtmlValidator.Validate();

            var cssValidator = new CssValidator("www.google.com");
            cssValidator.Validate();
        }
    }
}
