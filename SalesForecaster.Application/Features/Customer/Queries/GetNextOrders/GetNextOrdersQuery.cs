using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Order;

namespace SalesForecaster.Application.Features.Customer.Queries.GetNextOrders
{
    public class GetNextOrdersQuery : IRequest<ResultModel<List<NextOrderDto>>>
    {
    }
}
