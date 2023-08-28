using Apps.Acclaro.Callbacks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Acclaro.Callbacks
{
    [WebhookList]
    public class CallbackList
    {
        [Webhook("On order updated", Description = "On order updated")]
        public async Task<WebhookResponse<EmptyPayload>> OrderUpdated(WebhookRequest webhookRequest)
        {
            return new WebhookResponse<EmptyPayload>
            {
                HttpResponseMessage = null,
                Result = new EmptyPayload()
            };
        }

        [Webhook("On order comment added", Description = "On order comment added")]
        public async Task<WebhookResponse<EmptyPayload>> OrderCommentAdded(WebhookRequest webhookRequest)
        {
            return new WebhookResponse<EmptyPayload>
            {
                HttpResponseMessage = null,
                Result = new EmptyPayload()
            };
        }

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
        public async Task<WebhookResponse<EmptyPayload>> OrderFileUpdated(WebhookRequest webhookRequest)
        {
            return new WebhookResponse<EmptyPayload>
            {
                HttpResponseMessage = null,
                Result = new EmptyPayload()
            };
        }
    }
}
