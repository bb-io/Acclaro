namespace Apps.Acclaro.Models.Polling;

public class OrderStatusPollingMemory
{
    public DateTime? LastPollingTime { get; set; }

    public List<string> ProcessedOrderIdsAtLastPollingTime { get; set; } = [];
}
