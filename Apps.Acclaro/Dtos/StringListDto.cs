using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Dtos
{
    public class StringListDto
    {
        public int StringId { get; set; }
        public int BatchId { get; set; }
        public string SourceLang { get; set; }
        public string TargetLang { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string TranslatedValue { get; set; }
        public string Callback { get; set; }
        public string Status { get; set; }
    }
}
