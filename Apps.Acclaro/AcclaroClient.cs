using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Acclaro;

public class AcclaroClient(IEnumerable<AuthenticationCredentialsProvider> creds)
    : BlackBirdRestClient(new RestClientOptions
    {
        ThrowOnAnyError = false,
        BaseUrl = creds.Get("url").Value.TrimEnd('/').EndsWith("/api/v2", StringComparison.OrdinalIgnoreCase) 
            ? new Uri(creds.Get("url").Value.TrimEnd('/') + "/")
            : new Uri(creds.Get("url").Value.TrimEnd('/') + "/api/v2/")
    })
{
    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        var result = JsonConvert.DeserializeObject<ResponseWrapper<T>>(response.Content!);
        if (result == null || result.Data == null)
            throw new PluginApplicationException("Could not deserialize the response");
        
        return result.Data;
    }
    
    private async Task<ResponseWrapper<T>> ExecuteWrapperWithErrorHandling<T>(AcclaroRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        var result = JsonConvert.DeserializeObject<ResponseWrapper<T>>(response.Content!);
        if (result == null || result.Data == null)
            throw new PluginApplicationException("Could not deserialize the response");
        
        return result;
    }
    
    public async Task<List<T>> ExecutePaginatedAcclaro<T>(AcclaroRequest request)
    {
        request.AddOrUpdateParameter("perPage", 100);
        var page = 1;
        var resultList = new List<T>();

        while (true)
        {
            request.AddOrUpdateParameter("page", page);
            var result = await ExecuteWrapperWithErrorHandling<List<T>>(request);
            
            resultList.AddRange(result.Data!);
            page++;

            if (result.Pagination.Total == result.Pagination.To)
                break;
        }

        return resultList;
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        string statusCodePart = $"Status code: {(int)response.StatusCode} ({response.StatusCode}). ";
        string noErrorPart = "No error returned by the server.";
    
        if (string.IsNullOrWhiteSpace(response.Content))
        {
            string errorMessage = string.IsNullOrWhiteSpace(response.ErrorMessage) 
                ? noErrorPart
                : response.ErrorMessage;
        
            return new PluginApplicationException($"{statusCodePart}{errorMessage}");
        }

        if (response.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ResponseWrapper<object>>(response.Content);
            
                if (result != null && !result.Success)
                {
                    string message = !string.IsNullOrWhiteSpace(result.ErrorMessage) 
                        ? result.ErrorMessage 
                        : $"{statusCodePart}{noErrorPart}";
                    
                    return new PluginMisconfigurationException(message);
                }
            }
            catch (JsonException) { }
        }

        string rawMessage = response.Content.Substring(0, Math.Min(response.Content.Length, 300));
        return new PluginMisconfigurationException($"{statusCodePart}Raw Content: {rawMessage}");
    }
}