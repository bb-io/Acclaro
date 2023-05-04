using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Responses;
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
    public class QuoteActions
    {
        [Action("Get quote", Description = "Get quote by order Id")]
        public OrderDto? GetQuote(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/quote", Method.Get, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<OrderDto>>(request).Data;
        }

        [Action("Get quote details", Description = "Get quote details by order Id")]
        public QuoteDetailsDto? GetQuoteDetails(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/quote-details", Method.Get, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<QuoteDetailsDto>>(request).Data;
        }

        [Action("Approve quote", Description = "Approve quote by order Id")]
        public OrderDto? ApproveQuote(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/quote-approve", Method.Post, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<OrderDto>>(request).Data;
        }

        [Action("Decline quote", Description = "Decline quote by order Id")]
        public OrderDto? DeclineQuote(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                [ActionParameter] string orderId)
        {
            var client = new AcclaroClient();
            var request = new AcclaroRequest($"/orders/{orderId}/quote-decline", Method.Post, authenticationCredentialsProviders);
            return client.Get<ResponseWrapper<OrderDto>>(request).Data;
        }
    }
}
