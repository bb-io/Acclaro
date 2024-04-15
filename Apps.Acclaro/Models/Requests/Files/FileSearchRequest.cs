using Apps.Acclaro.DataSourceHandlers;
using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Acclaro.Models.Requests.Files;

public class FileSearchRequest
{
    [Display("Status")]
    [StaticDataSource(typeof(FileStatusHandler))]
    public string? Status { get; set; }

    [Display("Source languages", Description = "One or more source languages to match")]
    [DataSource(typeof(LanguageHandler))]
    public IEnumerable<string>? SourceLanguage { get; set; }

    [Display("Target language", Description = "One or more target languages to match")]
    [DataSource(typeof(LanguageHandler))]
    public IEnumerable<string>? TargetLanguage { get; set; }

    [Display("Type")]
    [StaticDataSource(typeof(FileTypeHandler))]
    public string? FileType { get; set; }
}