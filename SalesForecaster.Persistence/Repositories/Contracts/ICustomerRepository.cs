using SalesForecaster.Domain.Models;

namespace SalesForecaster.Persistence.Repositories.Contracts
{
    public interface ICustomerRepository : IGenericRepository<CustomerModel>
    {
        Task<IReadOnlyList<NextOrderModel>> GetCustomersNextOrders();
        Task<IReadOnlyList<CustomerModel>> GetCustomersFiltered(string parameter);
    }
}
