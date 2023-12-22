using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Requests.Strings;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Strings;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class StringActions : AcclaroInvocable
    {
        public StringActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Get order strings", Description = "Get a list of all string of order")]
        public async Task<ListAllStringsResponse> ListAllStrings([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/strings-info", Method.Get, Creds);
            var result = await Client.GetAsync<ResponseWrapper<List<StringListDto>>>(request);
            return new ListAllStringsResponse()
            {
                Strings = result.Data
            };
        }

        [Action("Add strings to order", Description = "Add strings to an existing order. Note: order process type should be string.")]
        public async Task AddString([ActionParameter] OrderRequest input, [ActionParameter] AddStringRequest stringData, [ActionParameter] LanguageRequest languages)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/strings", Method.Post, Creds);
            request.AddJsonBody(
                new
                {
                    strings = new[]
                    {
                        new
                        {
                            value = stringData.Value,
                            target_lang = languages.TargetLanguages ?? new List<string>(),
                            source_lang = languages.SourceLanguage,
                            key = stringData.Key,
                            callback = stringData.Callback,
                        }
                    }
                });
            await Client.ExecuteAsync(request);
        }

        //[Action("Get string", Description = "Get string by ID")]
        //public StringListDto? GetString(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        //        [ActionParameter] string orderId, [ActionParameter] string stringId)
        //{
        //    var client = new AcclaroClient();
        //    var request = new AcclaroRequest($"/orders/{orderId}/strings/{stringId}", Method.Get, authenticationCredentialsProviders);
        //    return client.Get<ResponseWrapper<StringListDto>>(request).Data;
        //}

    }
}
