using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class SearchOrderRequest
    {
        [Display("Status")]
        [DataSource(typeof(OrderStatusHandler))]
        public string? Status { get; set; }
    }
}
