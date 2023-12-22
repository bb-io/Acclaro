using Newtonsoft.Json;

namespace Apps.Acclaro.Models.Responses
{
    public class ResponseWrapper<T>
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T? Data { get; set; }

        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        [JsonProperty("errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string? ErrorMessage { get; set; }
    }
}
