using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class AddCallbackToFileRequest
    {
        [Display("Order ID")]
        public string OrderId { get; set; }

        [Display("File ID")]
        public string FileId { get; set; }

        [Display("Callback URL")]
        public string CallbackUrl { get; set; }
    }
}
