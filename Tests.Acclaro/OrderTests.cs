using Acclaro.Base;
using Apps.Acclaro.Actions;
using Apps.Acclaro.Models.Requests.Orders;

namespace Tests.Acclaro
{
    [TestClass]
    public class OrderTests : TestBase
    {
        [TestMethod]
        public async Task CreateOrder_IsSuccess()
        {
            var action = new OrderActions(InvocationContext);

            var result = await action.AddOrder(new CreateOrderRequest
            {
                Name = "Test Order from Unit Tests",
                ProgramId= "212"
            }, 
            new Apps.Acclaro.Models.Requests.LanguageRequest { });

            Console.WriteLine($"Created Order ID: {Newtonsoft.Json.JsonConvert.SerializeObject(result)}");

            Assert.IsNotNull(result);
        }

        //UpdateOrder

        [TestMethod]
        public async Task GetProgramsList_IsSuccess()
        {
            var action = new OrderActions(InvocationContext);

            var result = await action.GetProgramsList();

            Console.WriteLine($"{Newtonsoft.Json.JsonConvert.SerializeObject(result)}");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UpdateOrder_IsSuccess()
        {
            var action = new OrderActions(InvocationContext);

            var result = await action.UpdateOrder(new OrderRequest { Id= "90712" },new UpdateOrderRequest
            {
                Name = "Test Order from Unit Tests updated",
                ProgramId = "212"
            },
            new Apps.Acclaro.Models.Requests.LanguageRequest { });

            Console.WriteLine($"Created Order ID: {Newtonsoft.Json.JsonConvert.SerializeObject(result)}");

            Assert.IsNotNull(result);
        }
    }
}
