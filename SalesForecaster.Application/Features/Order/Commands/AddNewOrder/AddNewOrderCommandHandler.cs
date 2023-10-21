using MediatR;

namespace SalesForecaster.Application.Features.Order.Commands.AddNewOrder
{
    public class AddNewOrderCommandHandler : IRequestHandler<AddNewOrderCommand, int>
    {
        public Task<int> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
