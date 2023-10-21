using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public ShipperRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<ShipperModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<ShipperModel>(ShipperSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<ShipperModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<ShipperModel>(ShipperSQL.GetById, new { CategoryId = id }, transaction: _transaction);

            return result;
        }
    }
}
