using FluentValidation;
using SalesForecaster.Application.Features.Order.Commands.AddNewOrder;

namespace SalesForecaster.Presentation.API.Services
{
    public static class ValidationService
    {
        public static void AddValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddNewOrderCommand>, AddNewOrderCommandValidator>();
        }
    }
}
