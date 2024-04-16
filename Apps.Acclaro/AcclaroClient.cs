using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Acclaro;

public class AcclaroClient : RestClient
{
    public AcclaroClient(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(new RestClientOptions
    {
        ThrowOnAnyError = false, 
        BaseUrl = new Uri(authenticationCredentialsProviders.First(p => p.KeyName == "url").Value)
    }) { }

    public async Task ExecuteAcclaro(AcclaroRequest request)
    {
        var response = await ExecuteAsync(request);
        var result = JsonConvert.DeserializeObject<ResponseWrapper<object>>(response.Content);

        if (!result.Success)
            throw new Exception(result.ErrorMessage);
    }

    public async Task<T> ExecuteAcclaro<T>(AcclaroRequest request)
    {
        var response = await ExecuteAsync(request);  
        var result = JsonConvert.DeserializeObject<ResponseWrapper<T>>(response.Content);

        if (!result.Success)
            throw new Exception(result.ErrorMessage);

        return result.Data!;
    }

    public async Task<List<T>> ExecutePaginatedAcclaro<T>(AcclaroRequest request)
    {
        request.AddOrUpdateParameter("perPage", 100);
        var page = 1;
        var resultList = new List<T>();

        while (true)
        {
            request.AddOrUpdateParameter("page", page);
            var response = await ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<ResponseWrapper<List<T>>>(response.Content);

            if (!result.Success)
                throw new Exception(result.ErrorMessage);

            resultList.AddRange(result.Data);
            page++;

            if (result.Pagination.Total == result.Pagination.To)
                break;
        }

        return resultList;
    }
}