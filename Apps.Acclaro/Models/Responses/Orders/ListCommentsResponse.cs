using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Responses.Orders;

public class ListCommentsResponse
{
    [Display("Comments")]
    public IEnumerable<CommentResponse> Comments { get; set; }
}