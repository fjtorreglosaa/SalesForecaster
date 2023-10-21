using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Employee;

namespace SalesForecaster.Application.Features.Employee.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<ResultModel<List<GetEmployeeDto>>>
    {
        public PaginationDTO Filters { get; set; }
    }
}
