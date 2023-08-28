using Apps.Acclaro.Dtos;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class ListAllOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
