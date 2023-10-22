using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Order.Commands.AddNewOrder;
using SalesForecaster.Application.Features.Order.Queries.GetClientOrders;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : MainController
    {
        /// <summary>
        /// Get all the orders filtered by a customer
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet("ByCustomer")]
        public async Task<IActionResult> GetOrdersByCustomer(int clientId, int page = 1, int recordsPerPage = 10)
        {
            var query = new GetClientOrdersQuery
            { 
                ClientId = clientId,
                Filters = new PaginationDTO 
                { 
                    Page = page, 
                    RecordsPerPage = recordsPerPage 
                } 
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Add a new order and its details
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] AddNewOrderCommand order)
        {
            var result = await Mediator.Send(order);

            return Ok(result);
        }
    }
}
