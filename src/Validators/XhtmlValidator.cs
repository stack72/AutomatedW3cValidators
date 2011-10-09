using System;
using AutomatedW3cValidator.FileManager;
using EasyHttp.Http;
using Util.ConfigManager;

namespace AutomatedW3cValidator.Validators
{
    public interface IXhtmlValidator
    {
        string Url { get; set; }
        void Validate();
    }

    public class XhtmlValidator: IXhtmlValidator
    {
        private readonly IConfigManager _configManager;
        public string Url { get; set; }
        
        public XhtmlValidator(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Url))
                throw new ArgumentNullException("Url", "Url to validate must be specified");

            var urlToValidate = string.Format("{0}{1}",_configManager.GetAppSetting("XhtmlValidator"), Url);
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
