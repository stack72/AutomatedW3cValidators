using System;
using AutomatedW3cValidator.FileManager;
using EasyHttp.Http;
using Util.ConfigManager;

namespace AutomatedW3cValidator.Validators
{
    public interface ICssValidator
    {
        string Url { get; set; }
        void Validate();
    }
    
    public class CssValidator: ICssValidator
    {
        public string Url { get; set; }
        private readonly IConfigManager _configManager;

        public CssValidator(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Url))
                throw new ArgumentNullException("Url", "You must specify a URL to validate");

            var urlToValidate =
                string.Format("{0}{1}", _configManager.GetAppSetting("CssValidator"), Url);

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
