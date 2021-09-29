using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;
using System.Linq;

namespace Restaurant.Order.Tests.Domain
{
    [TestClass]
    public class NightDishesTests : DishesBaseTests
    {

        public NightDishesTests()
            : base(new NightDishes())
        {
        }

        [TestMethod]
        public void ShouldReturnAllValidPossibilities()
        {
            // arrange
            var dishTypes = new[] { 1, 2, 3, 4 };
            var expected = new[] { "steak", "potato", "wine", "cake" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }

        [TestMethod]
        public void ShouldReturnErrorForInvalidDishType()
        {
            // arrange
            var dishTypes = new[] { 5 };
            var expected = new[] { "error" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }

        [TestMethod]
        public void ShouldReturnMultiplesPotatos()
        {
            // arrange
            var dishTypes = new[] { 1, 2, 2, 4 };
            var expected = new[] { "steak", "potato(x2)", "cake" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }

        [TestMethod]
        public void ShouldReturnInTheFollowingOrderEntreeSideDrinkDessert()
        {
            // arrange
            var dishTypes = new[] { 3, 4, 2, 1 };
            var expected = new[] { "steak", "potato", "wine", "cake" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }
    }
}
