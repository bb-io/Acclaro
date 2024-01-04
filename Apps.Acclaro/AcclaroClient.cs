using Apps.Acclaro.Models.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Acclaro
{
    public class AcclaroClient : RestClient
    {
        public AcclaroClient() : base(new RestClientOptions
        {
            ThrowOnAnyError = false, 
            BaseUrl = new Uri("https://apisandbox.acclaro.com/api/v2")
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
    }
}
