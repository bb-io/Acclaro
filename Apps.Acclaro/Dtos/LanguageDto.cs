using Newtonsoft.Json;

namespace Apps.Acclaro.Dtos
{
    public class LanguageDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("code3")]
        public string Code3 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
