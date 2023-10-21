using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public OrderDetailRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<int> AddAsync(OrderDetailModel entity)
        {
            var result = await _connection.ExecuteAsync(OrderDetailSQL.AddOrderDetail, entity);

            return result;
        }

        public async Task<IReadOnlyList<OrderDetailModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<OrderDetailModel>(OrderDetailSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<IReadOnlyList<OrderDetailModel>> GetByOrderId(int orderId)
        {
            var result = await _connection.QueryAsync<OrderDetailModel>(OrderDetailSQL.GetByOrderId, new { OrderId = orderId }, transaction: _transaction);

            return result.ToList();
        }

        public async Task<OrderDetailModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<OrderDetailModel>(OrderDetailSQL.GetById, new { Id = id }, transaction: _transaction);

            return result;
        }
    }
}
