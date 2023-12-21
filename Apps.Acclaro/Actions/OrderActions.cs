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
        public async Task<OrderDto> AddOrder([ActionParameter] CreateOrderRequest input, [ActionParameter] LanguageRequest languages)
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

            var result = await Client.PostAsync<ResponseWrapper<OrderDto>>(request);

            var id = result.Data.Orderid;

            if (input.CallbackUrl != null)
            {
                var callbackRequest = new AcclaroRequest($"/orders/{id}/callback", Method.Post, Creds);
                callbackRequest.AddParameter("url", input.CallbackUrl);
                await Client.PostAsync(callbackRequest);
            }

            if (input.CallbackEmail != null)
            {
                var emailRequest = new AcclaroRequest($"/orders/{id}/email", Method.Post, Creds);
                emailRequest.AddParameter("email", input.CallbackEmail);
                await Client.PostAsync(emailRequest);
            }

            if (input.Tags != null)
            {
                var tagRequest = new AcclaroRequest($"/orders/{id}/tag", Method.Post, Creds);
                tagRequest.AddParameter("tag", string.Join(',', input.Tags));
                await Client.PostAsync(tagRequest);
            }

            if (languages.TargetLanguages != null)
            {
                foreach(var target in languages.TargetLanguages)
                {
                    if (languages.SourceLanguage != null)
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language", Method.Post, Creds);
                        request.AddParameter("targetlang", target);
                        await Client.PostAsync(langRequest);
                    }
                    else
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language-pair", Method.Post, Creds);
                        request.AddParameter("sourcelang", languages.SourceLanguage);
                        request.AddParameter("targetlang", target);
                        await Client.PostAsync(langRequest);
                    }
                }               
            }

            return result.Data;
        }

        [Action("Search orders", Description = "Search through all orders")]
        public async Task<ListOrdersResponse> SearchOrders([ActionParameter] SearchOrderRequest input)
        {
            var request = new AcclaroRequest("/orders", Method.Get, Creds);

            if (input.Status != null)
                request.AddQueryParameter("status", input.Status);

            var result = await Client.GetAsync<ResponseWrapper<List<OrderDto>>>(request);
            return new ListOrdersResponse()
            {
                Orders = result.Data
            };
        }

        [Action("Get order", Description = "Get order by ID")]
        public async Task<OrderDto> GetOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}", Method.Get, Creds);
            var result = await Client.GetAsync<ResponseWrapper<OrderDto>>(request);

            return result.Data;
        }

        // Todo: edit order

        [Action("Delete order", Description = "Delete order")]
        public void DeleteOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}", Method.Delete, Creds);
            Client.Execute(request);
        }

        [Action("Submit order", Description = "Submit order")]
        public void SubmitOrder([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/submit", Method.Post, Creds);
            Client.Execute(request);
        }
        
    }
}

