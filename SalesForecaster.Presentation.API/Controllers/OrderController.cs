using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Order.Queries.GetClientOrders;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrdersByCustomerId(int clientId, int page = 1, int recordsPerPage = 10)
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
    }
}
