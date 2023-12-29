using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Acclaro.DataSourceHandlers.EnumHandlers
{
    public class OrderProcessTypeHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "string", "String based" },
            { "", "File based" }
        };
    }
}
