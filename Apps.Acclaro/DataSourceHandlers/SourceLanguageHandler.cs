using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
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
    public class SourceLanguageHandler : AcclaroInvocable, IAsyncDataSourceHandler
    {
        public SourceLanguageHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            var request = new AcclaroRequest("/info/language-pairs", Method.Get, Creds);
            var result = await Client.ExecuteAcclaro<List<LanguageCombinationDto>>(request);

            return result
                .Where(x => x.Source.Code != null && x.Target.Code != null)
                .Where(x => (context.SearchString == null ||
                            x.Source.Description.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)))
                .Select(x => x.Source)
                .DistinctBy(x => x.Code)
                .ToDictionary(x => x.Code, x => x.Description);
        }
    }
}
