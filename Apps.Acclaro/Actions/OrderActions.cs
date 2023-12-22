using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Globalization;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class OrderActions : AcclaroInvocable
    {
        public OrderActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Create order", Description = "Create order")]
        public async Task<OrderResponse> AddOrder([ActionParameter] CreateOrderRequest input, [ActionParameter] LanguageRequest languages)
        {
            var request = new AcclaroRequest($"/orders", Method.Post, Creds);
            request.AddParameter("name", input.Name);

            if(input.Comment != null)
                request.AddParameter("comment", input.Comment);

            if(input.DueDate.HasValue)
                request.AddParameter("duedate", input.DueDate.Value.ToString("o", CultureInfo.InvariantCulture));

            if (input.Delivery != null)
                request.AddParameter("delivery", input.Delivery);

            if (input.EstimatedWordCount.HasValue)
                request.AddParameter("estwordcount", input.EstimatedWordCount.Value);

            if (input.ClientRef != null)
                request.AddParameter("clientref", input.ClientRef);

            if (input.Type != null)
                request.AddParameter("type", input.Type);

            if (!string.IsNullOrEmpty(input.ProcessType))
                request.AddParameter("process_type", input.ProcessType);

            var result = await Client.ExecuteAcclaro<OrderDto>(request);

            var id = result.Orderid;

            if (input.CallbackUrl != null)
            {
                var callbackRequest = new AcclaroRequest($"/orders/{id}/callback", Method.Post, Creds);
                callbackRequest.AddParameter("url", input.CallbackUrl);
                await Client.ExecuteAcclaro(callbackRequest);
            }

            if (input.CallbackEmail != null)
            {
                var emailRequest = new AcclaroRequest($"/orders/{id}/email", Method.Post, Creds);
                emailRequest.AddParameter("email", input.CallbackEmail);
                await Client.ExecuteAcclaro(emailRequest);
            }

            if (input.Tags != null)
            {
                var tagRequest = new AcclaroRequest($"/orders/{id}/tag", Method.Post, Creds);
                tagRequest.AddParameter("tag", string.Join(',', input.Tags));
                await Client.ExecuteAcclaro(tagRequest);
            }

            if (languages.TargetLanguages != null)
            {
                foreach(var target in languages.TargetLanguages)
                {
                    if (languages.SourceLanguage != null)
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language", Method.Post, Creds);
                        request.AddParameter("targetlang", target);
                        await Client.ExecuteAcclaro(langRequest);
                    }
                    else
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language-pair", Method.Post, Creds);
                        request.AddParameter("sourcelang", languages.SourceLanguage);
                        request.AddParameter("targetlang", target);
                        await Client.ExecuteAcclaro(langRequest);
                    }
                }               
            }

            return new(result);
        }

        [Action("Search orders", Description = "Search through all orders")]
        public async Task<ListOrdersResponse> SearchOrders([ActionParameter] SearchOrderRequest input)
        {
            var request = new AcclaroRequest("/orders", Method.Get, Creds);

            if (input.Status != null)
                request.AddQueryParameter("status", input.Status);

            var result = await Client.ExecuteAcclaro<List<OrderDto>>(request);
            return new ListOrdersResponse()
            {
                Orders = result.Select(x => new OrderResponse(x))
            };
        }

        [Action("Get order", Description = "Get order by ID")]
        public async Task<OrderResponse> GetOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}", Method.Get, Creds);
            var response = await Client.ExecuteAcclaro<OrderDto>(request);
            return new(response);
        }

        // Todo: edit order

        [Action("Delete order", Description = "Delete order")]
        public Task DeleteOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}", Method.Delete, Creds);
            return Client.ExecuteAcclaro(request);
        }

        [Action("Submit order", Description = "Submit order")]
        public Task SubmitOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/submit", Method.Post, Creds);
            return Client.ExecuteAcclaro(request);
        }
        
    }
}

