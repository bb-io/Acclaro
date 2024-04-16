using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.Models.Requests.Orders;

public class OptionalFormatInput
{
    [Display("Format")]
    [StaticDataSource(typeof(CommentFormatHandler))]
    public string? Format { get; set; }
}