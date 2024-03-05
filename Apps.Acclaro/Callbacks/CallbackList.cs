using Apps.Acclaro.Callbacks.Payload;
using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Responses.Files;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Acclaro.Callbacks
{
    [WebhookList]
    public class CallbackList : AcclaroInvocable
    {
        public CallbackList(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Webhook("On order updated", Description = "On order updated")]
        public async Task<WebhookResponse<OrderResponse>> OrderUpdated(WebhookRequest webhookRequest)
        {
            var orderId = webhookRequest.QueryParameters["orderId"];

            var request = new AcclaroRequest($"/orders/{orderId}", Method.Get, Creds);
            var response = await Client.ExecuteAcclaro<OrderDto>(request);

            return new WebhookResponse<OrderResponse>
            {
                HttpResponseMessage = null,
                Result = new(response)
            };
        }

        //[Webhook("On order comment added", Description = "On order comment added")]
        //public async Task<WebhookResponse<EmptyPayload>> OrderCommentAdded(WebhookRequest webhookRequest)
        //{
        //    return new WebhookResponse<EmptyPayload>
        //    {
        //        HttpResponseMessage = null,
        //        Result = new EmptyPayload()
        //    };
        //}

        [Webhook("On order string updated", Description = "On order string updated")]
        public async Task<WebhookResponse<StringUpdatePayload>> OrderStringUpdated(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<StringUpdatePayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }
            return new WebhookResponse<StringUpdatePayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On order file updated", Description = "On order file updated")]
        public async Task<WebhookResponse<FileInfoResponse>> OrderFileUpdated(WebhookRequest webhookRequest)
        {
            var orderId = webhookRequest.QueryParameters["orderId"];
            var fileId = webhookRequest.QueryParameters["fileId"];

            var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}/status", Method.Get, Creds);
            var response = await Client.ExecuteAcclaro<FileInfoDto>(request);

            return new WebhookResponse<FileInfoResponse>
            {
                HttpResponseMessage = null,
                Result = new(response)
            };
        }
    }
}
