using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Responses.Orders;

public class OrderExistsResponse
{
    [Display("Exists")]
    public bool Exists { get; set; }
}