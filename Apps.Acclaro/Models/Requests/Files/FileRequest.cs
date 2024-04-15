using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Files;

public class FileRequest
{
    [Display("File ID")]
    public string FileId { get; set; }
}