using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Orders;

public class NewCommentRequest
{
    [Display("Comment")]
    public string Comment { get; set; }
}