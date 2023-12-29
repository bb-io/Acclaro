using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Acclaro.Dtos
{
    public class StringDto
    {
        //[Display("String ID")]
        //[JsonProperty("string_id")]
        //public int StringId { get; set; }

        //[Display("Batch ID")]
        //[JsonProperty("batch_id")]
        //public int BatchId { get; set; }

        [Display("Source language code")]
        [JsonProperty("source_lang")]
        public string SourceLang { get; set; }

        [Display("Target language code")]
        [JsonProperty("target_lang")]
        public string TargetLang { get; set; }
   
        public string Key { get; set; }

        [Display("Source text")]
        public string Value { get; set; }

        [Display("Translated text")]
        [JsonProperty("translated_value")]
        public string TranslatedValue { get; set; }
        
        public string Callback { get; set; }
        
        public string Status { get; set; }
    }
}
