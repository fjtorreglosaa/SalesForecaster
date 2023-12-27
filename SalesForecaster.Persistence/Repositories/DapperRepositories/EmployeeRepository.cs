using Dapper;
using SalesForecaster.Domain.Models;
using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Utilities.SQLStrings;
using System.Data;
using static Dapper.SqlMapper;

namespace SalesForecaster.Persistence.Repositories.DapperRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbTransaction _transaction;
        private readonly IDbConnection _connection;

        public EmployeeRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = connection;
        }

        public async Task<IReadOnlyList<EmployeeModel>> GetEmployeeFiltered(string? parameter)
        {
            var query = "SELECT firstname, lastname, address, city, phone FROM StoreSample.HR.Employees WHERE firstname LIKE @Parameter";
            
            var result = await _connection.QueryAsync<EmployeeModel>(query, new { Parameter = $"%{parameter}%" }, transaction: _transaction);

            return result.ToList(); 
        }
            public async Task<IReadOnlyList<EmployeeModel>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<EmployeeModel>(EmployeeSQL.GetAll, transaction: _transaction);

            return result.ToList();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<EmployeeModel>(EmployeeSQL.GetById, new { CategoryId = id }, transaction:  _transaction);

            return result;
        }

    }
}
