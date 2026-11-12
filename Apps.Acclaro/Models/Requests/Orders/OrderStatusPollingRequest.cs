using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.Models.Requests.Orders;

public class OrderStatusPollingRequest
{
    [Display("Statuses", Description = "The statuses the order must reach")]
    [StaticDataSource(typeof(OrderStatusHandler))]
    public IEnumerable<string> Statuses { get; set; } = [];

    [Display("Order name contains", Description = "Optionally trigger only for orders whose name contains this text")]
    public string? OrderNameContains { get; set; }
}
