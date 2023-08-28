using Apps.Acclaro.Dtos;

namespace Apps.Acclaro.Models.Responses.Files
{
    public class ListFilesResponse
    {
        public IEnumerable<FileInfoStatusDto> Files { get; set; }
    }
}
