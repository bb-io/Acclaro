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
    public class OrderTypeHandler : AcclaroInvocable
    {
        public OrderTypeHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            var request = new AcclaroRequest("/info/order-types", Method.Get, Creds);
            var result = Client.Get<ResponseWrapper<List<OrderTypeDto>>>(request);

            return result.Data
                .Where(x => context.SearchString == null ||
                            x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(x => x.Name, x => x.Name);
        }
    }
}
