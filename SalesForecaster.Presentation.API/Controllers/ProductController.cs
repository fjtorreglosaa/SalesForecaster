using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Product.Queries.GetProducts;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : MainController
    {
        /// <summary>
        /// Get all the customers
        /// </summary>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int recordsPerPage = 10)
        {
            var filters = new PaginationDTO { Page = page, RecordsPerPage = recordsPerPage };

            var query = new GetProductsQuery { Filters = filters };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
