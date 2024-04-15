using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers;

public class FileStatusHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
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