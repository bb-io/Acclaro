using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Models.Responses.Orders
{
    public class OrderExistsResponse
    {
        [Display("Exists")]
        public bool Exists { get; set; }
    }
}
