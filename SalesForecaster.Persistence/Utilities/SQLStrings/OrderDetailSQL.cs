namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class OrderDetailSQL
    {
        public const string GetAll = @"SELECT 
	                                        orderid,
                                            productid,
                                            unitprice,
                                            qty,
                                            discount
                                        FROM StoreSample.Sales.OrderDetails";

        public const string GetById = @"SELECT 
	                                        orderid,
                                            productid,
                                            unitprice,
                                            qty,
                                            discount
                                        FROM StoreSample.Sales.OrderDetails
                                        WHERE CONCAT(orderid, productid) = @Id";
    }
}
