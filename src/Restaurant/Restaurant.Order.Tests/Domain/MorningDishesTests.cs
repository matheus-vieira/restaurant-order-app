using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;
using System.Linq;

namespace Restaurant.Order.Tests.Domain
{
    [TestClass]
    public class MorningDishesTests
    {
        readonly MorningDishes service;

        public MorningDishesTests()
        {
            service = new MorningDishes();
        }

        [TestMethod]
        public void ShouldReturnAllValidPossibilities()
        {
            // arrange
            var dishTypes = new[] { 1, 2, 3 };
            var expected = new[] { "eggs", "toast", "coffee" };

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
        public void ShouldReturnMultiplesCoffes()
        {
            // arrange
            var dishTypes = new[] { 1, 2, 3, 3, 3 };
            var expected = new[] { "eggs", "toast", "coffee(x3)" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }

        [TestMethod]
        public void ShouldReturnWithNoDessert()
        {
            // arrange
            var dishTypes = new[] { 1, 2, 3, 4 };
            var expected = new[] { "eggs", "toast", "coffee", "error" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }

        private void CheckPossibilities(int[] dishTypes, string[] expected)
        {
            // act
            var dishes = service.GetDishes(dishTypes);

            // assert
            Assert.IsTrue(dishes.Any(d => expected.Contains(d)));
        }
    }
}
