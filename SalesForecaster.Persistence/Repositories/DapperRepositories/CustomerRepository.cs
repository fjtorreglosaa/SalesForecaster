using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<CustomerModel>> GetCustomersFiltered(string parameter)
        {
            var query = "SELECT custid, contactname FROM StoreSample.Sales.Customers WHERE contactname LIKE " + $"'%{parameter}%'";

            var result = await _connection.QueryAsync<CustomerModel>(query, transaction: _transaction);

            return result.ToList();
        }

        public async Task<IReadOnlyList<CustomerModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<CustomerModel>(CustomerSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<CustomerModel>(CustomerSQL.GetById, new { CategoryId = id }, transaction: _transaction);

            return result;
        }

        public async Task<IReadOnlyList<NextOrderModel>> GetCustomersNextOrders()
        {
            var result = await _connection.QueryAsync<NextOrderModel>(CustomerSQL.GetCustomersNextOrders, transaction: _transaction);

            return result.ToList();
        }
    }
}
