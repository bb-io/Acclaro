using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Acclaro.Dtos;

public class LanguageDto
{
    [Display("Code")]
    [JsonProperty("code")]
    public string Code { get; set; }

    [Display("Code 3")]
    [JsonProperty("code3")]
    public string Code3 { get; set; }

    [Display("Description")]
    [JsonProperty("description")]
    public string Description { get; set; }
}