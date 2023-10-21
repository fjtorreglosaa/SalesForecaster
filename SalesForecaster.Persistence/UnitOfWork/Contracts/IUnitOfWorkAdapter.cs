namespace SalesForecaster.Persistence.UnitOfWork.Contracts
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }

        void Commit();
    }
}
