using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers
{
    public class DeliveryHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "email", "Email" },
            { "box", "Box" },
            { "dropbox", "Dropbox" },
            { "google", "Google" },
            { "zendesk", "Zendesk" },
            { "hubspot", "Hubspot" },
        };
    }
}
