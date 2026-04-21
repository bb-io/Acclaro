using Acclaro.Base;
using Apps.Acclaro.Actions;
using Apps.Acclaro.Models.Requests.Orders;
using Blackbird.Applications.Sdk.Common.Exceptions;

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

        [TestMethod]
        public async Task SearchOrders_ReturnsOrders()
        {
            // Arrange
            var action = new OrderActions(InvocationContext);
            var input = new SearchOrderRequest { };

            // Act
            var result = await action.SearchOrders(input);            
            
            // Assert
            PrintJsonResult(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetOrder_ExistingOrder_ReturnsOrder()
        {
            // Arrange
            var action = new OrderActions(InvocationContext);
            var orderRequest = new OrderRequest { Id = "90655" };

            // Act
            var result = await action.GetOrder(orderRequest);

            // Assert
            PrintJsonResult(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetOrder_NonExistingOrder_ThrowsMisconfigException()
        {
            // Arrange
            var action = new OrderActions(InvocationContext);
            var orderRequest = new OrderRequest { Id = "9065511111111" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(async () => 
                await action.GetOrder(orderRequest));
        }
    }
}
