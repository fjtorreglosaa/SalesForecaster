using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Order;

namespace SalesForecaster.Application.Features.Order.Queries.GetClientOrders
{
    public class GetClientOrdersQuery : IRequest<ResultModel<List<GetOrderDto>>>
    {
        public int ClientId { get; set; }
        public PaginationDTO Filters { get; set; }
    }
}
