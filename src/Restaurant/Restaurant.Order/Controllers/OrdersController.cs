using Microsoft.AspNetCore.Mvc;
using Restaurant.Order.Domain;
using System;

namespace Restaurant.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class OrdersController : ControllerBase
    {
        private readonly Func<string, IDishes> _serviceResolver;

        public OrdersController(
            Func<string, IDishes> serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        private IActionResult InternalGetDishes(string type, int[] dyshType)
        {
            var service = _serviceResolver(type);
            var list = service?.GetDishes(dyshType);
            return Ok(list);
        }
    }
}
