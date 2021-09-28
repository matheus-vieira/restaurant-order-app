using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Get dishes for each time of day
        /// </summary>
        /// <param name="timeofday">Time of the day, should be morning or night</param>
        /// <param name="dyshType">The requested dishes</param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost, Route("morning/")]
        public IActionResult GetMorning([FromBody] int[] dyshType)
        {
            return Ok(new[] { "morning fine" });
        }

        /// <summary>
        /// Get dishes for each time of day
        /// </summary>
        /// <param name="timeofday">Time of the day, should be morning or night</param>
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
            return Ok(new[] { "night fine" });
        }
    }
}
