using Apps.Acclaro.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Acclaro.Models.Requests
{
    public class RequiredLanguageRequest
    {
        [Display("Source language")]
        [DataSource(typeof(SourceLanguageHandler))]
        public string SourceLanguage { get; set; }

        [Display("Target languages")]
        [DataSource(typeof(TargetLanguageHandler))]
        public IEnumerable<string> TargetLanguages { get; set; }
    }
}
