
namespace AutomatedW3cValidator.Constants
{
    public static class DocType
    {
        public static string GetDocType(string documentType)
        {
            var docType = string.Empty;

            switch (documentType)
            {
                case "HTML5":
                    docType = "HTML5";
                    break;

                case "XHTML_10_STRICT":
                    docType = "XHTML+1.0+Strict";
                    break;

                case "XHTML_10_FRAMESET":
                    docType = "XHTML+1.0+Frameset";
                    break;

                default:
                    docType = "XHTML+1.0+Transitional";
                    break;
            }

            return docType;
        }
    }
}
    
