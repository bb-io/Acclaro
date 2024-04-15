using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Apps.Acclaro.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.Models.Requests.Orders;

public class UpdateOrderRequest
{
    [Display("Name")]
    public string? Name { get; set; }

    [Display("Comment")]
    public string? Comment { get; set; }

    [Display("Due date")]
    public DateTime? DueDate { get; set; }

    [Display("Delivery", Description = "Additional upload repositories for completed, translations besides the My Acclaro customer portal.")]
    [StaticDataSource(typeof(DeliveryHandler))]
    public string? Delivery { get; set; }

    [Display("Estimated word count", Description = "May be used to assist with making a quote for this order, if the information is available.")]
    public int? EstimatedWordCount { get; set; }

    [Display("Order type")]
    [DataSource(typeof(OrderTypeHandler))]
    public string? Type { get; set; }
}