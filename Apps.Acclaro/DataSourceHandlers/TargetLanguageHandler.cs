using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.DataSourceHandlers;

public class TargetLanguageHandler : AcclaroInvocable, IAsyncDataSourceHandler
{
    private LanguageRequest langRequest;
    public TargetLanguageHandler(InvocationContext invocationContext, [ActionParameter] LanguageRequest req) : base(invocationContext)
    {
        langRequest = req;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new AcclaroRequest("/info/language-pairs", Method.Get, Creds);
        var result = await Client.ExecuteAcclaro<List<LanguageCombinationDto>>(request);

        return result
            .Where(x => x.Source.Code != null && x.Target.Code != null)
            .Where(x => string.IsNullOrWhiteSpace(langRequest.SourceLanguage) || x.Source.Code == langRequest.SourceLanguage)
            .Where(x => context.SearchString == null ||
                        x.Target.Description.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Select(x => x.Target)
            .DistinctBy(x => x.Code)
            .ToDictionary(x => x.Code, x => x.Description);
    }
}