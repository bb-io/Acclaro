using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Dtos
{
    public class StringListDto
    {
        [Display("String ID")]
        [JsonPropertyName("string_id")]
        public int StringId { get; set; }

        [Display("Batch ID")]
        [JsonPropertyName("batch_id")]
        public int BatchId { get; set; }

        [Display("Source language")]
        [JsonPropertyName("source_lang")]
        public string SourceLang { get; set; }

        [Display("Target language")]
        [JsonPropertyName("target_lang")]
        public string TargetLang { get; set; }
   
        public string Key { get; set; }

        [Display("Source text")]
        public string Value { get; set; }

        [Display("Translated text")]
        [JsonPropertyName("translated_value")]
        public string TranslatedValue { get; set; }
        
        public string Callback { get; set; }
        
        public string Status { get; set; }
    }
}
