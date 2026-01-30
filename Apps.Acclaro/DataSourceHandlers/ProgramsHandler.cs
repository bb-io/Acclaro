using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.DataSourceHandlers;

public class ProgramsHandler : AcclaroInvocable, IAsyncDataSourceHandler
{
    public ProgramsHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new AcclaroRequest("/programs/list", Method.Get, Creds);
        var response = await Client.ExecuteAcclaro<ResponseWrapper<List<ProgramDto>>>(request);

        return response.Data
            .Where(x =>
                context.SearchString == null ||
                x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(
                x => x.Id.ToString(),
                x => x.Name);
    }
}
