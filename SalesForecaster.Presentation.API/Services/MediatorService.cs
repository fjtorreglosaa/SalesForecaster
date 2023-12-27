using SalesForecaster.Application.Features.Employee.Queries.GetEmployeedByFiltered;
using SalesForecaster.Application.Features.Employee.Queries.GetEmployees;
using SalesForecaster.Application.Features.Order.Commands.AddNewOrder;
using SalesForecaster.Application.Features.Order.Queries.GetClientOrders;
using SalesForecaster.Application.Features.Shipper.Queries.GetShippers;


namespace SalesForecaster.Presentation.API.Services
{
    public static class MediatorService
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetEmployeesQueryHandler)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(AddNewOrderCommandHandler)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetClientOrdersQueryHandler)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetEmployeesQueryHandler)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetShippersQueryHandler)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetEmployeeByFilteredQueryHandler)));


        }
    }
}
