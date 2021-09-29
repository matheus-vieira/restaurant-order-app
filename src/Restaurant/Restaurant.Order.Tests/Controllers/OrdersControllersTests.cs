using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Restaurant.Order.Tests.Controllers
{
    [TestClass]
    public class OrdersControllersTests : OrderControllersTestBase
    {
        public OrdersControllersTests() : base(default)
        {
        }

        [TestMethod]
        public void ShouldReturnNullOkObjectResult()
        {
            // act
            var actionResult = _controller.GetMorning(default) as OkObjectResult;

            // assert
            Assert.IsNotNull(actionResult);
            Assert.IsNull(actionResult.Value);
        }
    }
}
