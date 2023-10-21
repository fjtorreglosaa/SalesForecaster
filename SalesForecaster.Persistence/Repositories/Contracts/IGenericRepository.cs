using SalesForecaster.Domain.Models;

namespace SalesForecaster.Persistence.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : IModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
