using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.DataSourceHandlers
{
    public class OrderHandler : AcclaroInvocable
    {
        public OrderHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            var request = new AcclaroRequest("/orders", Method.Get, Creds);
            var result = await Client.GetAsync<ResponseWrapper<List<OrderDto>>>(request);

            return result.Data
                .Where(x => context.SearchString == null ||
                            x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Orderid, x => x.Name);
        }
    }
}
