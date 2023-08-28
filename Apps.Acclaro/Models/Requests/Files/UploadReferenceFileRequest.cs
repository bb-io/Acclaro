using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadReferenceFileRequest
    {
        public string OrderId { get; set; }
        public File File { get; set; }
    }
}
