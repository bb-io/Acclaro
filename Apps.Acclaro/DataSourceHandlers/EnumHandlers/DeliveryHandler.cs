using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers;

public class DeliveryHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "email", "Email" },
        { "box", "Box" },
        { "dropbox", "Dropbox" },
        { "google", "Google" },
        { "zendesk", "Zendesk" },
        { "hubspot", "Hubspot" },
    };
}