using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadReferenceFileRequest
    {
        [Display("Order ID")]
        public string OrderId { get; set; }
        
        public File File { get; set; }
    }
}
