using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro
{
    public class AcclaroClient : RestClient
    {
        public AcclaroClient() : base(new RestClientOptions() { ThrowOnAnyError = true, BaseUrl = new Uri("https://apisandbox.acclaro.com/api/v2") }) { }
    }
}
