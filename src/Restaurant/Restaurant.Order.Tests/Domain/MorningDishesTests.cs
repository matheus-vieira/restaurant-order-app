﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;

namespace Restaurant.Order.Tests.Domain
{
    [TestClass]
    public class MorningDishesTests : DishesBaseTests
    {
        public MorningDishesTests()
            : base(new MorningDishes())
        {
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

        [TestMethod]
        public void ShouldReturnInTheFollowingOrderEntreeSideDrinkDessert()
        {
            // arrange
            var dishTypes = new[] { 3, 2, 1 };
            var expected = new[] { "eggs", "toast", "coffe" };

            // act
            // assert
            CheckPossibilities(dishTypes, expected);
        }
    }
}