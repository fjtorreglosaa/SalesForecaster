using SalesForecaster.Domain.Models;

namespace SalesForecaster.Persistence.Repositories.Contracts
{
    public interface IOrderRepository : IGenericRepository<OrderModel>
    {
        Task<int> AddAsync(OrderModel entity);
        Task<IReadOnlyList<OrderModel>> GetByCustomerIdAsync(int id);
    }
}
