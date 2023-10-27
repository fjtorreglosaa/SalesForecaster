namespace SalesForecaster.Application.Exceptions
{
    public class EntityException : ApplicationException
    {
        public EntityException(string name, object key) : base($"Entity \"{name}\" ({key}) already exists.")
        {

        }
    }
}
