using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class StringListDto
    {
        [JsonPropertyName("string_id")]
        public int StringId { get; set; }

        [JsonPropertyName("batch_id")]
        public int BatchId { get; set; }

        [JsonPropertyName("source_lang")]
        public string SourceLang { get; set; }

        [JsonPropertyName("target_lang")]
        public string TargetLang { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        [JsonPropertyName("translated_value")]
        public string TranslatedValue { get; set; }
        public string Callback { get; set; }
        public string Status { get; set; }
    }
}
