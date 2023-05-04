using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Strings
{
    public class AddStringRequest
    {
        public string Value { get; set; }
        public List<string> TargetLang { get; set; }
        public string SourceLang { get; set; }
        public string Key { get; set; }
        public string Callback { get; set; }
    }
}
