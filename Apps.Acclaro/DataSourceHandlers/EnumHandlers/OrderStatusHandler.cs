using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

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
