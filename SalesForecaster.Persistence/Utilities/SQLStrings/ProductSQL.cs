namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class ProductSQL
    {
        public const string GetAll = @"SELECT 
	                                        productid,
	                                        productname,
	                                        supplierid,
	                                        categoryid,
	                                        unitprice,
	                                        discontinued
                                        FROM StoreSample.Production.Products";

        public const string GetById = @"SELECT 
	                                        productid,
	                                        productname,
	                                        supplierid,
	                                        categoryid,
	                                        unitprice,
	                                        discontinued
                                        FROM StoreSample.Production.Products
										WHERE productid = @ProductId";
    }
}
