using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Dtos
{
    public class StringDto
    {
        public string Value { get; set; }
        
        [Display("Target language")]
        [JsonPropertyName("target_lang")]
        public List<string> TargetLang { get; set; }

        [Display("Source language")]
        [JsonPropertyName("source_lang")]
        public string SourceLang { get; set; }
        
        public string Key { get; set; }
        
        public string Callback { get; set; }

        [Display("String ID")]
        [JsonPropertyName("string_id")]
        public int StringId { get; set; }
    }
}
