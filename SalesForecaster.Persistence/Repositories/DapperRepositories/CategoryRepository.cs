using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public CategoryRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<CategoryModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<CategoryModel>(CategorySQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<CategoryModel>(CategorySQL.GetById, new { CategoryId = id }, transaction: _transaction);

            return result;
        }
    }
}
