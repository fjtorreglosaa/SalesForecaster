using MediatR;
using SalesForecaster.Application.Utilities;
using SalesForecaster.Application.Utilities.Dtos.Order;

namespace SalesForecaster.Application.Features.Order.Commands.AddNewOrder
{
    public class AddNewOrderCommand : IRequest<ResultModel<List<string>>>
    {
        public AddOrderDto Order { get; set; }
    }
}
