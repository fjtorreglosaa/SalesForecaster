namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class CategorySQL
    {
        public const string GetAll = @"SELECT 
                                           categoryid, 
                                           categoryname, 
                                           description 
                                       FROM StoreSample.Production.Categories";

        public const string GetById = @"SELECT 
                                           categoryid, 
                                           categoryname, 
                                           description 
                                       FROM StoreSample.Production.Categories
                                       WHERE categoryid = @CategoryId";
    }
}
