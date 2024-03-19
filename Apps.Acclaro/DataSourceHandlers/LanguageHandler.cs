using Apps.Acclaro.Dtos;
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
    public class LanguageHandler : AcclaroInvocable, IAsyncDataSourceHandler
    {
        public LanguageHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            var request = new AcclaroRequest("/info/languages", Method.Get, Creds);
            var result = await Client.ExecuteAcclaro<List<LanguageDto>>(request);

            return result
                .Where(x => (context.SearchString == null ||
                            x.Description.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)))
                .DistinctBy(x => x.Code)
                .ToDictionary(x => x.Code, x => x.Description);
        }
    }
}
