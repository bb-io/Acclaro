using Apps.Acclaro.Callbacks.Payload;
using Apps.Acclaro.DataSourceHandlers.EnumHandlers;
using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Requests.Files;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Requests.Strings;
using Apps.Acclaro.Models.Responses.Files;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Acclaro.Callbacks;

[WebhookList]
public class CallbackList(InvocationContext invocationContext) : AcclaroInvocable(invocationContext)
{
    [Webhook("On order updated", Description = "On order updated")]
    public async Task<WebhookResponse<OrderResponse>> OrderUpdated(WebhookRequest webhookRequest, 
        [WebhookParameter][Display("Status")][StaticDataSource(typeof(OrderStatusHandler))] string? orderStatus,
        [WebhookParameter] OrderOptionalRequest orderOptionalRequest)
    {
        var orderId = webhookRequest.QueryParameters["orderId"];

        var request = new AcclaroRequest($"/orders/{orderId}", Method.Get, Creds);
        var response = await Client.ExecuteAcclaro<OrderDto>(request);
        var result = new OrderResponse(response);
        
        if (orderStatus != null && response.Status != orderStatus)
        {
            return new WebhookResponse<OrderResponse>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }
        
        if(orderOptionalRequest.Id != null && result.Orderid != orderOptionalRequest.Id)
        {
            return new WebhookResponse<OrderResponse>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }

        return new WebhookResponse<OrderResponse>
        {
            HttpResponseMessage = null,
            Result = result
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
    public async Task<WebhookResponse<StringUpdatePayload>> OrderStringUpdated(WebhookRequest webhookRequest,
        [WebhookParameter] StringOptionalRequest stringOptionalRequest)
    {
        var data = JsonConvert.DeserializeObject<StringUpdatePayload>(webhookRequest.Body.ToString());
        if (data is null)
        {
            throw new InvalidCastException(nameof(webhookRequest.Body));
        }
        
        if (stringOptionalRequest.StringId != null && data.Id != stringOptionalRequest.StringId)
        {
            return new WebhookResponse<StringUpdatePayload>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }
        
        return new WebhookResponse<StringUpdatePayload>
        {
            HttpResponseMessage = null,
            Result = data
        };
    }

    [Webhook("On order file updated", Description = "On order file updated")]
    public async Task<WebhookResponse<FileInfoResponse>> OrderFileUpdated(WebhookRequest webhookRequest, 
        [WebhookParameter][Display("Status")][StaticDataSource(typeof(FileStatusHandler))] string? fileStatus,
        [WebhookParameter] OrderOptionalRequest orderOptionalRequest,
        [WebhookParameter] FileOptionalRequest fileOptionalRequest)
    {
        var orderId = webhookRequest.QueryParameters["orderId"];
        var fileId = webhookRequest.QueryParameters["fileId"];

        var request = new AcclaroRequest($"/orders/{orderId}/files/{fileId}/status", Method.Get, Creds);
        var response = await Client.ExecuteAcclaro<FileInfoDto>(request);
        var fileInfo =  new FileInfoResponse(response);

        if (fileStatus != null && response.Status != fileStatus)
        {
            return new WebhookResponse<FileInfoResponse>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }
        
        if(orderOptionalRequest.Id != null && fileInfo.OrderId != orderOptionalRequest.Id)
        {
            return new WebhookResponse<FileInfoResponse>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }
        
        if(fileOptionalRequest.FileId != null && fileInfo.FileId != fileOptionalRequest.FileId)
        {
            return new WebhookResponse<FileInfoResponse>
            {
                HttpResponseMessage = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                Result = null
            };
        }

        return new WebhookResponse<FileInfoResponse>
        {
            HttpResponseMessage = null,
            Result = fileInfo
        };
    }
}