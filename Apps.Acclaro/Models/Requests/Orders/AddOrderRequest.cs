using Blackbird.Applications.Sdk.Common;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class AddOrderRequest
    {
        public string Name { get; set; }
        
        public string Comment { get; set; }
        
        [Display("Due date")]
        public string DueDate { get; set; }
    }
}
