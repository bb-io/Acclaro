using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Acclaro;

public class AcclaroRequest : RestRequest
{
    public AcclaroRequest(string endpoint, Method method, 
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
    {
        var apiToken = authenticationCredentialsProviders.First(p => p.KeyName == "apiToken").Value;
        this.AddHeader("Authorization", $"Bearer {apiToken}");
    }

    public void AddParameters(Dictionary<string, string> queryParameters)
    {
        if (queryParameters == null || !queryParameters.Any())
        {
            return;
        }
        foreach (var queryParameter in queryParameters.Where(x => x.Value is not null))
        {
            this.AddParameter(queryParameter.Key, queryParameter.Value);
        }
    }
}