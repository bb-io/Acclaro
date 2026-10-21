using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Orders;

public class AddOrderTagsRequest
{
    [Display("Tags", Description = "Comma-separated tags to add to the order")]
    public string Tags { get; set; }
}
