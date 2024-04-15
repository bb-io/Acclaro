using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.Models.Requests.Orders;

public class SearchOrderRequest
{
    [Display("Status")]
    [StaticDataSource(typeof(OrderStatusHandler))]
    public string? Status { get; set; }
}