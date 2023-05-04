using System.Text.Json.Serialization;

namespace Apps.Acclaro.Dtos
{
    public class StringDto
    {
        public string Value { get; set; }

        [JsonPropertyName("target_lang")]
        public List<string> TargetLang { get; set; }

        [JsonPropertyName("source_lang")]
        public string SourceLang { get; set; }
        public string Key { get; set; }
        public string Callback { get; set; }

        [JsonPropertyName("string_id")]
        public int StringId { get; set; }
    }
}
