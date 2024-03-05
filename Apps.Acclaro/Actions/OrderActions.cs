using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System;
using System.Globalization;
using System.Web;
using System.Xml.Linq;

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
                var builder = new UriBuilder(input.CallbackUrl);
                var paramValues = HttpUtility.ParseQueryString(builder.Query);
                paramValues.Add("orderId", id.ToString());
                builder.Query = paramValues.ToString();

                var callbackRequest = new AcclaroRequest($"/orders/{id}/callback", Method.Post, Creds);
                callbackRequest.AddParameter("url", builder.Uri.ToString());
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
                    if (languages.SourceLanguage == null)
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language", Method.Post, Creds);
                        langRequest.AddParameter("targetlang", target);
                        await Client.ExecuteAcclaro(langRequest);
                    }
                    else
                    {
                        var langRequest = new AcclaroRequest($"/orders/{id}/language-pair", Method.Post, Creds);
                        langRequest.AddParameter("sourcelang", languages.SourceLanguage);
                        langRequest.AddParameter("targetlang", target);
                        await Client.ExecuteAcclaro(langRequest);
                    }
                }               
            }

            return new(result);
        }

        [Action("Update order", Description = "UPdate order")]
        public async Task<OrderResponse> UpdateOrder([ActionParameter] OrderRequest order, [ActionParameter] UpdateOrderRequest input, [ActionParameter] LanguageRequest languages)
        {
            var currentOrderRequest = new AcclaroRequest($"/orders/{order.Id}", Method.Get, Creds);
            var currentOrder = await Client.ExecuteAcclaro<OrderDto>(currentOrderRequest);

            var request = new AcclaroRequest($"/orders/{order.Id}", Method.Post, Creds);
            request.AddParameter("name", input.Name ?? currentOrder.Name);

            request.AddParameter("comment", input.Comment ?? currentOrder.Comments);

            if (input.DueDate.HasValue || currentOrder.Duedate.HasValue)
                request.AddParameter("duedate", input.DueDate.HasValue ? input.DueDate.Value.ToString("o", CultureInfo.InvariantCulture) : currentOrder.Duedate!.Value.ToString("o", CultureInfo.InvariantCulture));

            request.AddParameter("delivery", input.Delivery ?? currentOrder.Delivery);

            request.AddParameter("estwordcount", input.EstimatedWordCount.HasValue ? input.EstimatedWordCount.Value : currentOrder.Estimatedwordcount);

            request.AddParameter("type", input.Type ?? currentOrder.Ordertype);

            var result = await Client.ExecuteAcclaro<OrderDto>(request);

            if (languages.TargetLanguages != null)
            {
                foreach (var target in languages.TargetLanguages)
                {
                    if (languages.SourceLanguage == null)
                    {
                        var langRequest = new AcclaroRequest($"/orders/{order.Id}/language", Method.Post, Creds);
                        langRequest.AddParameter("targetlang", target);
                        await Client.ExecuteAcclaro(langRequest);
                    }
                    else
                    {
                        var langRequest = new AcclaroRequest($"/orders/{order.Id}/language-pair", Method.Post, Creds);
                        langRequest.AddParameter("sourcelang", languages.SourceLanguage);
                        langRequest.AddParameter("targetlang", target);
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

        [Action("Add order comment", Description = "Add a new comment to an order")]
        public Task AddComment([ActionParameter] OrderRequest input, [ActionParameter] NewCommentRequest newComment)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/comment", Method.Post, Creds);
            request.AddParameter("comment", newComment.Comment);
            return Client.ExecuteAcclaro(request);
        }

        [Action("Update order comment", Description = "Updates an exisitng order comment (note: changes comment ID)")]
        public Task UpdateComment([ActionParameter] OrderRequest input, [ActionParameter] CommentRequest comment, [ActionParameter] NewCommentRequest newComment)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/comment/{comment.CommentId}", Method.Post, Creds);
            request.AddParameter("comment", newComment.Comment);
            return Client.ExecuteAcclaro(request);
        }

        [Action("Get order comments", Description = "Get a list of all comments attached to an order")]
        public async Task<ListCommentsResponse> GetComments([ActionParameter] OrderRequest input, [ActionParameter] OptionalFormatInput format)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/comments", Method.Get, Creds);

            if (format.Format != null)
                request.AddQueryParameter("format", format.Format);

            var result = await Client.ExecuteAcclaro<List<CommentDto>>(request);

            return new ListCommentsResponse()
            {
                Comments = result.Select(x => new CommentResponse(x))
            };
        }

    }
}

