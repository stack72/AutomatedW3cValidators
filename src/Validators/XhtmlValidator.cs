using System;
using AutomatedW3cValidator.FileManager;
using EasyHttp.Http;

namespace AutomatedW3cValidator.Validators
{
    public class XhtmlValidator
    {
        private readonly string _url;
        public XhtmlValidator(string url)
        {
            _url = url;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(_url))
                throw new ArgumentNullException("url", "Url to validate must be specified");

            var urlToValidate = string.Format("http://validator.w3.org/check?uri=http%3A%2F%2F{0}", _url);
            var http = new HttpClient
            {
                Request = { Accept = HttpContentTypes.TextHtml }
            };

            var response = http.Get(urlToValidate);
            var validationSummary = response.RawText;

            FileSave.SaveTheResponse(validationSummary, "XHTMLReport.html");
        }
    }
}
