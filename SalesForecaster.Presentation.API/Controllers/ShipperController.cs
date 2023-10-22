using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Shipper.Queries.GetShippers;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : MainController
    {
        /// <summary>
        /// Get all the providers
        /// </summary>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetShippersQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
