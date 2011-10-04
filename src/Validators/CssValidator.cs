using System;
using System.IO;
using System.Web.UI;
using AutomatedW3cValidator.FileManager;
using EasyHttp.Http;

namespace AutomatedW3cValidator.Validators
{
    public class CssValidator
    {
        private readonly string _url;
        public CssValidator(string url)
        {
            _url = url;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(_url))
                throw new ArgumentNullException("You must specify a URL to validate");

            var urlToValidate =
                string.Format(
                    "http://jigsaw.w3.org/css-validator/validator?uri=http%3A%2F%2F{0}%2F&warning=0&profile=css2", _url);

            var http = new HttpClient
                           {
                               Request = { Accept = HttpContentTypes.TextHtml }
                           };

            var response = http.Get(urlToValidate);
            var validationSummary = response.RawText;

            FileSave.SaveTheResponse(validationSummary, "CSSReport.html");
        }
    }
}
