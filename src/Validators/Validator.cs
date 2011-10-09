using System;
using AutomatedW3cValidator.FileManager;
using EasyHttp.Http;
using Util.ConfigManager;

namespace AutomatedW3cValidator.Validators
{
    public class Validator : IValidator
    {
        private readonly IConfigManager _configManager;

        public string Url { get; set; }
        public ValidatorType ValidatorType { get; set; }

        public Validator(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Url))
                throw new ArgumentNullException("Url", "Url to validate must be specified");

            var appSettingName = string.Format("{0}Validator", ValidatorType);
            var urlToValidate = string.Format("{0}{1}", _configManager.GetAppSetting(appSettingName), Url);
            var http = new HttpClient
            {
                Request = { Accept = HttpContentTypes.TextHtml }
            };

            var response = http.Get(urlToValidate);
            var validationSummary = response.RawText;

            var reportName = string.Format("{0}Report.html", ValidatorType);
            FileSave.SaveTheResponse(validationSummary, reportName);
        }
    }
}
