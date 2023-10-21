using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Customer.Queries;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : MainController
    {
        /// <summary>
        /// Get all the Shippers
        /// </summary>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int recordsPerPage = 10)
        {
            var filters = new PaginationDTO { Page = page, RecordsPerPage = recordsPerPage };

            var query = new GetNextOrdersQuery { Filters = filters };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
