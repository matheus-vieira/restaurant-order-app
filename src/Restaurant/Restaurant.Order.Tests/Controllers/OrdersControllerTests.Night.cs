using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;
using System.Collections.Generic;

namespace Restaurant.Order.Tests.Controllers
{
    [TestClass]
    public class OrderControllersTestNight : OrderControllersTestBase
    {
        public OrderControllersTestNight()
            : base(new NightDishes())
        {
        }

        public static IEnumerable<object[]> ValuesToMatch()
        {
            yield return new object[] { new[] { 1, 2, 3, 4 }, new[] { "steak", "potato", "wine", "cake" } };
            yield return new object[] { new[] { 5 }, new[] { "error" } };
            yield return new object[] { new[] { 1, 2, 2, 4 }, new[] { "steak", "potato(x2)", "cake" } };
            yield return new object[] { new[] { 3, 4, 2, 1 }, new[] { "steak", "potato", "wine", "cake" } };
        }
        [TestMethod]
        [DynamicData(nameof(ValuesToMatch), DynamicDataSourceType.Method)]
        public void CompareInputWithOutput(int[] dishTypes, string[] expected)
        {
            CheckPossibilities(dishTypes, expected);
        }
    }
}
