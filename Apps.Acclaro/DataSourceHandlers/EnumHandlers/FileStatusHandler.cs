using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers
{
    public class FileStatusHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "new", "New" },
            { "in preparation", "In preparation" },
            { "getting quote", "Getting quote" },
            { "needs approval", "Needs approval" },
            { "in progress", "In progress" },
            { "in review", "In review" },
            { "preview", "Preview" },
            { "complete", "Complete" },
            { "canceled", "Canceled" },
        };
    }
}
