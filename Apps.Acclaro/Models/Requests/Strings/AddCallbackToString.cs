using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Strings
{
    public class AddCallbackToString
    {
        [Display("Callback URL")]
        public string CallbackUrl { get; set; }

        public string Key { get; set; }
    }
}
