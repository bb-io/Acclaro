using Apps.Acclaro.Dtos;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Apps.Acclaro.DataSourceHandlers
{
    public class OrderHandler : AcclaroInvocable, IAsyncDataSourceHandler
    {
        public OrderHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            var request = new AcclaroRequest("/orders", Method.Get, Creds);
            var orders = await Client.ExecuteAcclaro<List<OrderDto>>(request);

            return orders
                .Where(x => context.SearchString == null ||
                            x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase) || x.Orderid.ToString().Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Orderid.ToString(), x => $"{x.Orderid}: {x.Name}");
        }
    }
}
