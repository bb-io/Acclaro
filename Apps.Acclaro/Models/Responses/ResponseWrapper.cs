using Newtonsoft.Json;

namespace Apps.Acclaro.Models.Responses;

public class ResponseWrapper<T>
{
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public T? Data { get; set; }

    [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
    public bool Success { get; set; }

    [JsonProperty("errorMessage", NullValueHandling = NullValueHandling.Ignore)]
    public string? ErrorMessage { get; set; }

    [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
    public Pagination Pagination { get; set; }
}

public class Pagination
{
    [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
    public int CurrentPage { get; set; }

    [JsonProperty("last_page", NullValueHandling = NullValueHandling.Ignore)]
    public int LastPage { get; set; }

    [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
    public int To { get; set; }

    [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
    public int Total { get; set; }
}