namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class CustomerSQL
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

        public const string GetCustomersNextOrders = @"SELECT 
	                                                        custid,
                                                            companyname,
                                                            LatestOrderDate,
                                                            DATEADD(DAY, AverageNextDate, LatestOrderDate) AS NextPredictedOrder
                                                        FROM (
                                                            SELECT
                                                                c.companyname,
                                                                c.custid,
                                                                MAX(o.orderdate) AS LatestOrderDate,
                                                                AVG(DATEDIFF(DAY, o.orderdate, GETDATE())) AS AverageNextDate
                                                            FROM Sales.Orders o
                                                            INNER JOIN Sales.Customers c ON o.custid = c.custid
                                                            GROUP BY c.companyname, c.custid
                                                        ) AS Subquery";
    }
}
