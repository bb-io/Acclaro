using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Acclaro.Models.Requests
{
    public class ProgramDto
    {
        [JsonProperty("id")]
        [Display("Program ID")]
        public string Id { get; set; }

        [JsonProperty("name")]
        [Display("Program name")]
        public string Name { get; set; } = default!;
    }
}
