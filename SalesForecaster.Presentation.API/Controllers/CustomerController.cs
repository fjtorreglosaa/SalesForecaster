using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Customer.Queries.GetNextOrders;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : MainController
    {
        /// <summary>
        /// Get all the Customers
        /// </summary>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet("GetNextOrders")]
        public async Task<IActionResult> Get()
        {
            var query = new GetNextOrdersQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
