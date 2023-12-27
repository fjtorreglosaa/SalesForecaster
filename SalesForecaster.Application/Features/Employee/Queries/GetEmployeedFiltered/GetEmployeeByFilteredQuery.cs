using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Employee;

namespace SalesForecaster.Application.Features.Employee.Queries.GetEmployeedFiltered
{
    public class GetEmployeeByFilteredQuery : IRequest<ResultModel<List<GetEmployeeDto>>>
    {
        public string? Filter { get; set; }
    }
}
