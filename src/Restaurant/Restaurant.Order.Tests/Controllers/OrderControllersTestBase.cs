using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.AutoMock;
using Restaurant.Order.Controllers;
using Restaurant.Order.Domain;
using System;
using System.Linq;

namespace Restaurant.Order.Tests.Controllers
{
    public abstract class OrderControllersTestBase
    {
        private readonly AutoMocker _mocker;
        private readonly IDishes _service;
        protected readonly OrdersController _controller;
        private readonly Func<string, IDishes> _serviceResolver;

        public OrderControllersTestBase(IDishes service)
        {
            _service = service;
            _serviceResolver = (type) => _service;
            _mocker = new AutoMocker();
            _mocker.Use(_serviceResolver);
            _controller = _mocker.CreateInstance<OrdersController>();
        }

        protected abstract object CallMethod(int[] dishTypes);

        protected void CheckPossibilities(int[] dishTypes, string[] expected)
        {
            // act
            var actionResult = CallMethod(dishTypes) as OkObjectResult;

            // assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Value, typeof(string[]));
            var dishes = actionResult.Value as string[];
            Assert.IsTrue(dishes.Any(d => expected.Contains(d)));
        }
    }
}
