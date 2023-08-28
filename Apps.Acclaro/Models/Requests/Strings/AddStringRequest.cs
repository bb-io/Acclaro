using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Strings
{
    public class AddStringRequest
    {
        public string Value { get; set; }
        
        [Display("Target language")]
        public string TargetLang { get; set; }
        
        [Display("Source language")]
        public string SourceLang { get; set; }
        
        public string Key { get; set; }
        
        public string Callback { get; set; }
    }
}
