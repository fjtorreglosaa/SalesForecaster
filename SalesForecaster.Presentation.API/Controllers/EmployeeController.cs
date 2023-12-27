using Microsoft.AspNetCore.Mvc;
using SalesForecaster.Application.Features.Employee.Queries.GetEmployeedFiltered;
using SalesForecaster.Application.Features.Employee.Queries.GetEmployees;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : MainController
    {
        /// <summary>
        /// Get all the Employees
        /// </summary>
        /// <param name="page"></param>
        /// <param name="recordsPerPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetEmployeesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }
        /// <summary>
        /// Get Employees Filtered
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeByFiltered")]
        public async Task<IActionResult> GetEmployeeByFiltered([FromQuery] string? parameter)
        {
            var query = new GetEmployeeByFilteredQuery { Filter = parameter };
            
            var result = await Mediator.Send(query);

            return Ok(result);
        }

    }
}
