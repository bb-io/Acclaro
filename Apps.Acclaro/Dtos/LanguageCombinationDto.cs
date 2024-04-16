using Newtonsoft.Json;

namespace Apps.Acclaro.Dtos;

public class LanguageCombinationDto
{
    [JsonProperty("source")]
    public LanguageDto Source { get; set; }

    [JsonProperty("target")]
    public LanguageDto Target { get; set; }
}