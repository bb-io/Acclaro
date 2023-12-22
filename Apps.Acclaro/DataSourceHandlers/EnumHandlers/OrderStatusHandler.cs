using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers
{
    internal class OrderStatusHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "new", "New" },
            { "in preparation", "In preparation" },
            { "getting quote", "Getting quote" },
            { "needs approval", "Needs approval" },
            { "in progress", "In progress" },
            { "in review", "In review" },
            { "complete", "Complete" },
            { "canceled", "Canceled" },
        };
    }
}
