using Apps.Acclaro.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class ListAllOrdersResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
