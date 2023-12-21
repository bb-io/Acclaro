using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Strings
{
    public class AddStringRequest
    {
        [Display("Text")]
        public string Value { get; set; }

        [Display("Key")]
        public string Key { get; set; }

        [Display("Callback URL")]
        public string? Callback { get; set; }
    }
}
