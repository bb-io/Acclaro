using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers;

public class FileTypeHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "source", "Source file" },
        { "target", "Target file" }
    };
}