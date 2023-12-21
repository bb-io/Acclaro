using Apps.Acclaro.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests
{
    public class LanguageRequest
    {
        [Display("Source language")]
        [DataSource(typeof(SourceLanguageHandler))]
        public string? SourceLanguage { get; set; }

        [Display("Target languages")]
        [DataSource(typeof(TargetLanguageHandler))]
        public IEnumerable<string>? TargetLanguages { get; set; }
    }
}
