using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Customer;

namespace SalesForecaster.Application.Features.Customer.Queries.GetCustomersByFilter
{
    public class GetCustomersByFilterQuery : IRequest<ResultModel<List<GetCustomerDto>>>
    {
        public string Filter { get; set; }
    }
}
