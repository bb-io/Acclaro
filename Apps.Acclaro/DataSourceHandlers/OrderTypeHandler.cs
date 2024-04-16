using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.DataSourceHandlers;

public class OrderTypeHandler : AcclaroInvocable, IAsyncDataSourceHandler
{
    public OrderTypeHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new AcclaroRequest("/info/order-types", Method.Get, Creds);
        var result = await Client.ExecuteAcclaro<List<OrderTypeDto>>(request);

        return result
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Name, x => x.Name);
    }
}