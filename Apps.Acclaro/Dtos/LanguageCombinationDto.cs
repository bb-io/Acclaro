using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class LanguageCombinationDto
    {
        [JsonProperty("source")]
        public LanguageDto Source { get; set; }

        [JsonProperty("target")]
        public LanguageDto Target { get; set; }
    }
}
