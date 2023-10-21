using MediatR;
using SalesForecaster.Application.Utilities.Dtos.Order;

namespace SalesForecaster.Application.Features.Order.Commands.AddNewOrder
{
    public class AddNewOrderCommand : IRequest<int>
    {
        public AddOrderDto OrderDetails { get; set; }
    }
}
