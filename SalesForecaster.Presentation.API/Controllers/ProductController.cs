using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Product.Queries.GetProducts;

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
        public async Task<IActionResult> Get()
        {
            var query = new GetProductsQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
