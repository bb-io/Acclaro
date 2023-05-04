using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests.Files;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Requests.Strings;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Orders;
using Apps.Acclaro.Models.Responses.Strings;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class StringActions
    {
        [Action("List strings", Description = "Get a list of all string of order")]
        public ListAllStringsResponse? ListAllStrings(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/strings-info", Method.Get, authenticationCredentialsProviders);
            var result = client.Get<ResponseWrapper<List<StringListDto>>>(request);
            return new ListAllStringsResponse()
            {
                Strings = result.Data
            };
        }

        [Action("Add strings to order", Description = "Add strings to order")]
        public StringDto? AddString(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] AddStringRequest stringData)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/strings", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(
                new
                {
                    strings = new[]
                    {
                        new
                        {
                            value = stringData.Value,
                            target_lang = new[] { stringData.TargetLang },
                            source_lang = stringData.SourceLang,
                            key = stringData.Key,
                            callback = stringData.Callback,
                        }
                    }
                });
            return client.Execute<ResponseWrapper<StringsWrapper>>(request).Data.Data.Strings.First();
        }

        [Action("Get string", Description = "Get string by Id")]
        public StringListDto? GetString(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId, [ActionParameter] string stringId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/strings/{stringId}", Method.Get, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<StringListDto>>(request).Data;
        }

        [Action("Add callback to string", Description = "Add callback to string")]
        public void AddCallbackToString(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] AddCallbackToString input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/strings/callback", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("callback", input.CallbackUrl);
            request.AddParameter("key", input.Key);
            client.Execute(request);
        }
    }
}
