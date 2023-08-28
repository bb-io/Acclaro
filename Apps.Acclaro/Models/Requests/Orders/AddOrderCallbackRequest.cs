using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class AddOrderCallbackRequest
    {
        [Display("Order ID")]
        public string OrderId { get; set; }

        [Display("Callback URL")]
        public string CallbackUrl { get; set; }
    }
}
