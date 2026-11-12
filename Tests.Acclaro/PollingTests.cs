using Acclaro.Base;
using Apps.Acclaro.Models.Polling;
using Apps.Acclaro.Models.Requests.Orders;
using Apps.Acclaro.Polling;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Tests.Acclaro;

[TestClass]
public class PollingTests : TestBase
{
    [TestMethod]
    public async Task OnOrderReachesStatus_IsSuccess()
    {
        var pollingList = new PollingList(InvocationContext);
        var request = new PollingEventRequest<OrderStatusPollingMemory>
        {
            Memory = new OrderStatusPollingMemory
            {
                LastPollingTime = DateTime.UtcNow.AddMinutes(-15)
            },
            PollingTime = DateTime.UtcNow
        };

        var response = await pollingList.OnOrderReachesStatus(
            request,
            new OrderStatusPollingRequest
            {
                Statuses = ["in preparation"],
                OrderNameContains = "POLLING"
            });

        PrintJsonResult(response);

        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Memory);
        Assert.IsNotNull(response.Memory.LastPollingTime);

        if (response.FlyBird)
        {
            Assert.IsNotNull(response.Result);
            Assert.IsTrue(response.Result!.Count > 0);
        }
    }
}
