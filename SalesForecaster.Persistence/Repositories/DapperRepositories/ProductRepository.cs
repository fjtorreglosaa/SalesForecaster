using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<ProductModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<ProductModel>(ProductSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<ProductModel>(ProductSQL.GetById, new { CategoryId = id }, transaction: _transaction);

            return result;
        }
    }
}
