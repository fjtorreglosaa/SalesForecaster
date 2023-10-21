using Microsoft.Extensions.Configuration;
using SalesForecaster.Persistence.UnitOfWork.Contracts;

namespace SalesForecaster.Persistence.UnitOfWork.DapperUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString)) connectionString = _configuration.GetConnectionString("StoreSampleDB");

            return new UnitOfWorkAdapter(connectionString);
        }
    }
}
