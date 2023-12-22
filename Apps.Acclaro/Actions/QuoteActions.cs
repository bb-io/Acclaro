﻿using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Acclaro.Actions
{
    [ActionList]
    public class QuoteActions : AcclaroInvocable
    {
        public QuoteActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Request quote", Description = "Request a quote for an order")]
        public void GetQuote([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/quote", Method.Get, Creds);
            Client.Execute(request);
        }

        //[Action("Get quote details", Description = "Get quote details by order ID")]
        //public QuoteDetailsDto? GetQuoteDetails(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        //        [ActionParameter] string orderId)
        //{
        //    var client = new AcclaroClient();
        //    var request = new AcclaroRequest($"/orders/{orderId}/quote-details", Method.Get, authenticationCredentialsProviders);
        //    return client.Get<ResponseWrapper<QuoteDetailsDto>>(request).Data;
        //}

        [Action("Approve quote", Description = "Approve an order for which a quote was requested")]
        public void ApproveQuote([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/quote-approve", Method.Post, Creds);
            Client.Execute(request);
        }

        [Action("Decline quote", Description = "Decline an order for which a quote was requested")]
        public void DeclineQuote([ActionParameter] OrderRequest input)
        {
            var request = new AcclaroRequest($"/orders/{input.Id}/quote-decline", Method.Post, Creds);
            Client.Execute(request);
        }
    }
}
