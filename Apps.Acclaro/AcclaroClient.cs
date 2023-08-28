using RestSharp;

namespace Apps.Acclaro
{
    public class AcclaroClient : RestClient
    {
        public AcclaroClient() : base(new RestClientOptions
        {
            ThrowOnAnyError = true, 
            BaseUrl = new Uri("https://apisandbox.acclaro.com/api/v2")
        }) { }
    }
}
