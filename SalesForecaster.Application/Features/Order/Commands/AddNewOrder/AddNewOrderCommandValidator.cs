using FluentValidation;

namespace SalesForecaster.Application.Features.Order.Commands.AddNewOrder
{
    public class AddNewOrderCommandValidator : AbstractValidator<AddNewOrderCommand>
    {
        public AddNewOrderCommandValidator()
        {
            RuleFor(x => x.Order.ShipName).NotEmpty();
        }
    }
}
