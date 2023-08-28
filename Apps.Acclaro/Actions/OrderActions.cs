using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class OrderActions
    {
        [Action("List orders", Description = "Get a list of all orders")]
        public ListAllOrdersResponse? ListAllOrders(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest("/orders", Method.Get, authenticationCredentialsProviders);
            var result = client.Get<ResponseWrapper<List<OrderDto>>>(request);
            return new ListAllOrdersResponse()
            {
                Orders = result.Data
            };
        }

        [Action("Get order", Description = "Get order by ID")]
        public OrderDto? GetOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}", Method.Get, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<OrderDto>>(request).Data;
        }

        [Action("Create order", Description = "Create order")]
        public OrderDto? AddOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AddOrderRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("name", input.Name);
            request.AddParameter("comment", input.Comment);
            request.AddParameter("duedate", input.DueDate);
            return client.Execute<ResponseWrapper<OrderDto>>(request).Data.Data;
        }

        [Action("Delete order", Description = "Delete order")]
        public void DeleteOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }

        [Action("Add target language", Description = "Add target language to order")]
        public OrderDto? AddTargetLanguageToOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] string languageCode)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/language", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("targetlang", languageCode);
            return client.Execute<ResponseWrapper<OrderDto>>(request).Data.Data;
        }

        [Action("Add target and source languages", Description = "Add target and source languages to order")]
        public OrderDto? AddTargetAndSourceLanguageToOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId, [ActionParameter] string sourceLanguageCode, [ActionParameter] string targetLanguageCode)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/language-pair", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("sourcelang", sourceLanguageCode);
            request.AddParameter("targetlang", targetLanguageCode);
            client.Execute(request);
            return client.Execute<ResponseWrapper<OrderDto>>(request).Data.Data;
        }

        [Action("Submit order", Description = "Submit order")]
        public void SubmitOrder(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/submit", Method.Post, authenticationCredentialsProviders);
            client.Execute(request);
        }

        [Action("Add order callback", Description = "Add order update callback")]
        public void AddOrderCallback(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] AddOrderCallbackRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/callback", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("url", input.CallbackUrl);
            client.Execute(request);
        }

        [Action("Remove order callback", Description = "Remove order update callback")]
        public void RemoveOrderCallback(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/callback", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }

        [Action("Add order comment callback", Description = "Add order comment callback")]
        public void AddOrderCommentCallback(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] AddOrderCallbackRequest input)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{input.OrderId}/comment/callback", Method.Post, authenticationCredentialsProviders);
            request.AddParameter("url", input.CallbackUrl);
            client.Execute(request);
        }

        [Action("Remove order comment callback", Description = "Remove order comment callback")]
        public void RemoveOrderCommentCallback(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/comment/callback", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }
    }
}

