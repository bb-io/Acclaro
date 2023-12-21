using Apps.Acclaro.Dtos;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class ListOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
