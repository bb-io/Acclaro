using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Strings;

public class StringOptionalRequest
{
    [Display("String ID")]
    public string? StringId { get; set; }
}