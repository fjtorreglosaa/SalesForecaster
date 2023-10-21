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

        public const string GetByOrderId = @"SELECT 
	                                            orderid,
                                                productid,
                                                unitprice,
                                                qty,
                                                discount
                                            FROM StoreSample.Sales.OrderDetails
                                            WHERE orderid = @OrderId";

        public const string AddOrderDetail = @"INSERT INTO (orderid, productid, unitprice, qty, discount) VALUES (@OrderId, @ProductId, @UnitPrice, @Qty, @Discount)";
    }
}
