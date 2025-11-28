using Acclaro.Base;
using Apps.Acclaro.DataSourceHandlers;

namespace Tests.Acclaro
{
    [TestClass]
    public class DataSources : TestBase
    {
        [TestMethod]
        public async Task OrderHandler_ReturnsValues()
        {
            var handler = new OrderHandler(InvocationContext);

            var result = await handler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
            }, CancellationToken.None);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task SourceLanguageHandler_ReturnsValues()
        {
            var handler = new SourceLanguageHandler(InvocationContext);

            var result = await handler.GetDataAsync(new Blackbird.Applications.Sdk.Common.Dynamic.DataSourceContext
            {
            }, CancellationToken.None);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Assert.IsNotNull(result);
        }
    }
}
