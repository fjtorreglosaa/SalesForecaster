using SalesForecaster.Persistence.Repositories.Contracts;

namespace SalesForecaster.Persistence.UnitOfWork.Contracts
{
    public interface IUnitOfWorkRepository
    {
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IShipperRepository ShipperRepository { get; }
        ISupplierRepository SupplierRepository { get; }
    }
}
