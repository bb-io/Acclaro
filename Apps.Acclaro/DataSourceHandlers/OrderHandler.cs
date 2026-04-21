using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.DataSourceHandlers;

public class OrderHandler(InvocationContext invocationContext)
    : AcclaroInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new AcclaroRequest("/orders", Method.Get, Creds);
        var orders = await Client.ExecuteWithErrorHandling<List<OrderDto>>(request);

        return orders
            .Where(x => context.SearchString == null ||
                        (x.Name != null && x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)) || x.Orderid.ToString().Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Orderid.ToString(), x => $"{x.Orderid}: {x.Name}");
    }
}