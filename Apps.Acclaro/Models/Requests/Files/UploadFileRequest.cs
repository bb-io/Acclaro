using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class UploadFileRequest
    {
        public string OrderId { get; set; }
        public string Sourcelang { get; set; }
        public string Targetlang { get; set; }
        public File File { get; set; }
    }
}
