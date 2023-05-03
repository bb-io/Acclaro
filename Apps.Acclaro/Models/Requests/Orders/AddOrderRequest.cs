using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class AddOrderRequest
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string DueDate { get; set; }
    }
}
