using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Responses.Files;

public class SearchFilesResponse
{
    [Display("Files")]
    public IEnumerable<FileInfoResponse> Files { get; set; }
}