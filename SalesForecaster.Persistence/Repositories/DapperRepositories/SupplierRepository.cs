using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public SupplierRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<SupplierModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<SupplierModel>(SupplierSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<SupplierModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<SupplierModel>(SupplierSQL.GetById, new { CategoryId = id }, transaction: _transaction);

            return result;
        }
    }
}
