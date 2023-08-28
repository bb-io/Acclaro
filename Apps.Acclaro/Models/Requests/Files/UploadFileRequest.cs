using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadFileRequest
    {
        [Display("Order ID")]
        public string OrderId { get; set; }
        
        [Display("Source language")]
        public string Sourcelang { get; set; }
        
        [Display("Target language")]
        public string Targetlang { get; set; }
        
        public File File { get; set; }
    }
}
