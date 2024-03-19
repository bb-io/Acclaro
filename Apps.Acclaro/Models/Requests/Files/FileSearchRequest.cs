using Apps.Acclaro.DataSourceHandlers;
using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Files
{
    public class FileSearchRequest
    {
        [Display("Status")]
        [DataSource(typeof(FileStatusHandler))]
        public string? Status { get; set; }

        [Display("Source languages", Description = "One or more source languages to match")]
        [DataSource(typeof(LanguageHandler))]
        public IEnumerable<string>? SourceLanguage { get; set; }

        [Display("Target language", Description = "One or more target languages to match")]
        [DataSource(typeof(LanguageHandler))]
        public IEnumerable<string>? TargetLanguage { get; set; }

        [Display("Type")]
        [DataSource(typeof(FileTypeHandler))]
        public string? FileType { get; set; }
    }
}
