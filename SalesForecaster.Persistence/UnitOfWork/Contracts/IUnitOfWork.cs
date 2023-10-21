namespace SalesForecaster.Persistence.UnitOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create(string connectionString = null);
    }
}
