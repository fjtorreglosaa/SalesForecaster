using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Employee.Queries.GetEmployees;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1,  int recordsPerPage = 10)
        {
            var filters = new PaginationDTO { Page = page, RecordsPerPage = recordsPerPage };

            var query = new GetEmployeesQuery { Filters = filters };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
