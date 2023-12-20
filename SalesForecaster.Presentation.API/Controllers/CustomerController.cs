using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Customer.Queries.GetCustomersByFilter;
using SalesForecaster.Application.Features.Customer.Queries.GetNextOrders;
using SalesForecaster.Application.Features.Order.Queries.GetClientOrders;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet("GetCustomersFiltered")]
        public async Task<IActionResult> GetCustomersByFilter([FromQuery] string parameter)
        {
            var query = new GetCustomersByFilterQuery { Filter = parameter };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
