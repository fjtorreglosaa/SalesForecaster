using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public OrderRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<OrderModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<OrderModel>(OrderSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<OrderModel>(OrderSQL.GetById, new { OrderId = id }, transaction: _transaction);

            return result;
        }

        public async Task<IReadOnlyList<OrderModel>> GetByCustomerIdAsync(int id)
        {
            var result = await _connection.QueryAsync<OrderModel>(OrderSQL.GetByCustomerId, new { CustId = id }, transaction: _transaction);

            return result.ToList();
        }

        public async Task<int> AddAsync(OrderModel entity)
        {
            var data = await _connection.QueryAsync<Entity>(OrderSQL.AddOrder, entity, transaction: _transaction);

            var result = data.FirstOrDefault();

            return result.Id;
        }
    }
}
