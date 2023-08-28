using Apps.Acclaro.Dtos;

namespace Apps.Acclaro.Models.Responses.Strings
{
    public class ListAllStringsResponse
    {
        public IEnumerable<StringListDto> Strings { get; set; }
    }
}
