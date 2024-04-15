using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers;

public class CommentFormatHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
        => new()
        {
            { "text", "Text" },
            { "html", "HTML" },
        };
}