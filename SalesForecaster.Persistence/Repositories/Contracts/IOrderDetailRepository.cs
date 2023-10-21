using SalesForecaster.Domain.Models;

namespace SalesForecaster.Persistence.Repositories.Contracts
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailModel>
    {
        Task<int> AddAsync(OrderDetailModel entity);
        Task<IReadOnlyList<OrderDetailModel>> GetByOrderId(int orderId);
    }
}
