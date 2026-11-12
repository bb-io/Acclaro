using Apps.Acclaro.Dtos;
using Apps.Acclaro.Models.Polling;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Models.Responses.Orders;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;
using System.Globalization;

namespace Apps.Acclaro.Polling;

[PollingEventList]
public class PollingList(InvocationContext invocationContext) : AcclaroInvocable(invocationContext)
{
    private const int MaxEventsPerPoll = 100;

    [PollingEvent("On order reaches status", Description = "Triggered when an order reaches one of the specified statuses")]
    [MultipleEvents]
    public async Task<PollingEventResponse<OrderStatusPollingMemory, List<OrderResponse>>> OnOrderReachesStatus(
        PollingEventRequest<OrderStatusPollingMemory> request,
        [PollingEventParameter] OrderStatusPollingRequest input)
    {
        var pollingStartedAt = DateTime.UtcNow;

        if (request.Memory?.LastPollingTime is null)
        {
            return new PollingEventResponse<OrderStatusPollingMemory, List<OrderResponse>>
            {
                FlyBird = false,
                Memory = new OrderStatusPollingMemory { LastPollingTime = pollingStartedAt },
                Result = null
            };
        }

        var windowStart = EnsureUtc(request.Memory.LastPollingTime.Value);
        var ordersWithTransitionTimes = new List<OrderPollingCandidate>();
        foreach (var status in input.Statuses.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            var requestMessage = new AcclaroRequest("/orders", Method.Get, Creds);
            requestMessage.AddQueryParameter("status", status);

            var orders = await Client.ExecutePaginatedAcclaro<OrderDto>(requestMessage);
            ordersWithTransitionTimes.AddRange(orders.Select(order => new OrderPollingCandidate(
                order,
                GetStatusTransitionTime(order, status))));
        }

        var processedIdsAtWindowStart = request.Memory.ProcessedOrderIdsAtLastPollingTime?.ToHashSet() ?? [];

        var matchingOrders = ordersWithTransitionTimes
            .Where(item => item.TransitionTime.HasValue)
            .Select(item => new OrderPollingCandidate(
                item.Order,
                EnsureUtc(item.TransitionTime!.Value)))
            .Where(item =>
                (item.TransitionTime > windowStart ||
                 (processedIdsAtWindowStart.Count > 0 &&
                  item.TransitionTime == windowStart &&
                  !processedIdsAtWindowStart.Contains(item.Order.Orderid.ToString()))) &&
                item.TransitionTime <= pollingStartedAt)
            .Where(item =>
                string.IsNullOrWhiteSpace(input.OrderNameContains) ||
                item.Order.Name?.Contains(input.OrderNameContains, StringComparison.OrdinalIgnoreCase) == true)
            .DistinctBy(item => item.Order.Orderid)
            .OrderBy(item => item.TransitionTime)
            .ThenBy(item => item.Order.Orderid)
            .ToList();

        var batch = matchingOrders.Take(MaxEventsPerPoll).ToList();
        var nextMemory = matchingOrders.Count > MaxEventsPerPoll
            ? CreateBacklogMemory(request.Memory, windowStart, batch)
            : new OrderStatusPollingMemory { LastPollingTime = pollingStartedAt };

        return new PollingEventResponse<OrderStatusPollingMemory, List<OrderResponse>>
        {
            FlyBird = batch.Count > 0,
            Memory = nextMemory,
            Result = batch.Count > 0
                ? batch.Select(item => new OrderResponse(item.Order)).ToList()
                : null
        };
    }

    private static OrderStatusPollingMemory CreateBacklogMemory(
        OrderStatusPollingMemory previousMemory,
        DateTime windowStart,
        IEnumerable<OrderPollingCandidate> batch)
    {
        var batchItems = batch.ToList();
        var lastTransitionTime = batchItems[^1].TransitionTime!.Value;
        var processedIds = lastTransitionTime == windowStart
            ? previousMemory.ProcessedOrderIdsAtLastPollingTime?.ToHashSet() ?? []
            : new HashSet<string>();

        foreach (var item in batchItems.Where(item => item.TransitionTime!.Value == lastTransitionTime))
        {
            processedIds.Add(item.Order.Orderid.ToString());
        }

        return new OrderStatusPollingMemory
        {
            LastPollingTime = lastTransitionTime,
            ProcessedOrderIdsAtLastPollingTime = processedIds.ToList()
        };
    }

    private static DateTime? GetStatusTransitionTime(OrderDto order, string status)
        => status.ToLowerInvariant() switch
        {
            "new" => order.Created,
            "in preparation" => ParseTransitionTime(order.StatusInPreparationAt, order.InPreparation),
            "getting quote" => ParseTransitionTime(order.StatusGettingQuoteAt, order.GettingQuote),
            "needs approval" => ParseTransitionTime(order.StatusNeedsApprovalAt, order.NeedsApproval),
            "in progress" => ParseTransitionTime(order.StatusInProgressAt, order.InProgress),
            "in review" => ParseTransitionTime(order.StatusInReviewAt, order.InReview),
            "complete" => ParseTransitionTime(order.StatusCompletedAt, order.Completed),
            "canceled" => ParseTransitionTime(order.StatusCanceledAt, order.Canceled),
            _ => null
        };

    private static DateTime? ParseTransitionTime(params string?[] values)
    {
        foreach (var value in values.Where(value => !string.IsNullOrWhiteSpace(value)))
        {
            if (DateTimeOffset.TryParse(
                    value,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                    out var timestamp))
            {
                return timestamp.UtcDateTime;
            }
        }

        return null;
    }

    private static DateTime EnsureUtc(DateTime value)
        => value.Kind switch
        {
            DateTimeKind.Utc => value,
            DateTimeKind.Local => value.ToUniversalTime(),
            _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
        };

    private sealed record OrderPollingCandidate(OrderDto Order, DateTime? TransitionTime);
}
