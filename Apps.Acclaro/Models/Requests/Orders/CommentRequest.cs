using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Orders;

public class CommentRequest
{
    [Display("Comment ID")]
    public string CommentId { get; set; }
}