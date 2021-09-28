using Microsoft.AspNetCore.Mvc;
using Restaurant.Order.Domain;

namespace Restaurant.Order.Controllers
{
    public partial class OrdersController
    {

        /// <summary>
        /// Get dishes for morning
        /// </summary>
        /// <param name="dyshType">The requested dishes</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost, Route("night/")]
        public IActionResult GetNight([FromBody] int[] dyshType)
        {
            return InternalGetDishes(NightDishes.Name, dyshType);
        }
    }
}
