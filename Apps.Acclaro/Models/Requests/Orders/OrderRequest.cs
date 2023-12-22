using Apps.Acclaro.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Requests.Orders
{
    public class OrderRequest
    {
        [Display("Order ID")]
        [DataSource(typeof(OrderHandler))]
        public string Id { get; set; }
    }
}
