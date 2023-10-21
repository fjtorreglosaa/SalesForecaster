using SalesForecaster.Persistence.Repositories.Contracts;
using SalesForecaster.Persistence.Repositories.DapperRepositories;
using SalesForecaster.Persistence.UnitOfWork.Contracts;
using System.Data;

namespace SalesForecaster.Persistence.UnitOfWork.DapperUnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IShipperRepository ShipperRepository { get; set; }
        public ISupplierRepository SupplierRepository { get; set; }

        public UnitOfWorkRepository(IDbConnection connection, IDbTransaction transaction)
        {
            CategoryRepository = new CategoryRepository(connection, transaction);
            CustomerRepository = new CustomerRepository(connection, transaction);
            EmployeeRepository = new EmployeeRepository(connection, transaction);
            OrderRepository = new OrderRepository(connection, transaction);
            OrderDetailRepository = new OrderDetailRepository(connection, transaction);
            ProductRepository = new ProductRepository(connection, transaction);
            ShipperRepository = new ShipperRepository(connection, transaction);
            SupplierRepository = new SupplierRepository(connection, transaction);
        }
    }
}
