using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;
using System.Collections.Generic;

namespace Restaurant.Order.Tests.Domain
{
    [TestClass]
    public class MorningDishesTests : DishesBaseTests
    {
        public MorningDishesTests()
            : base(new MorningDishes())
        {
        }

        public static IEnumerable<object[]> ValuesToMatch()
        {
            yield return new object[] { new[] { 1, 2, 3 }, new[] { "eggs", "toast", "coffee" } };
            yield return new object[] { new[] { 1, 1, 2, 3 }, new[] { "toast", "coffee" } };
            yield return new object[] { new[] { 5 }, new[] { "error" } };
            yield return new object[] { new[] { 1, 2, 3, 3, 3 }, new[] { "eggs", "toast", "coffee(x3)" } };
            yield return new object[] { new[] { 1, 2, 3, 4 }, new[] { "eggs", "toast", "coffee", "error" } };
            yield return new object[] { new[] { 3, 2, 1 }, new[] { "eggs", "toast", "coffe" } };
        }
        [DataTestMethod]
        [DynamicData(nameof(ValuesToMatch), DynamicDataSourceType.Method)]
        public void CompareInputWithOutput(int[] dishTypes, string[] expected)
        {
            CheckPossibilities(dishTypes, expected);
        }
    }
}
