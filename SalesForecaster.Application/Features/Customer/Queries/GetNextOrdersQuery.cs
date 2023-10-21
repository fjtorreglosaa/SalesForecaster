using MediatR;
using SalesForecaster.Application.Utilities;

namespace SalesForecaster.Application.Features.Customer.Queries
{
    public class GetNextOrdersQuery : IRequest<ResultModel<List<NextOrderDTO>>>
    {
        public PaginationDTO Filters { get; set; }
    }
}
