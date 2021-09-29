using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Order.Domain;
using System;
using System.Linq;

namespace Restaurant.Order.Tests.Domain
{
    public class DishesBaseTests
    {
        protected readonly IDishes _service;

        public DishesBaseTests(IDishes service)
        {
            _service = service;
        }

        protected void CheckPossibilities(int[] dishTypes, string[] expected)
        {
            // act
            var dishes = _service.GetDishes(dishTypes);

            // assert
            Assert.IsTrue(dishes.Any(d => expected.Contains(d)));
        }
    }
}
