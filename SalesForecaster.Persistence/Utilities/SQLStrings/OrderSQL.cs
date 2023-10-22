namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class OrderSQL
    {
        public const string GetAll = @"SELECT
                                           orderid,
                                           custid,
                                           empid,
                                           orderdate,
                                           requireddate,
                                           shippeddate,
                                           shipperid,
                                           freight,
                                           shipname,
                                           shipaddress,
                                           shipcity,
                                           shipregion,
                                           shippostalcode,
                                           shipcountry
                                       FROM StoreSample.Sales.Orders";

        public const string GetById = @"SELECT
                                           orderid,
                                           custid,
                                           empid,
                                           orderdate,
                                           requireddate,
                                           shippeddate,
                                           shipperid,
                                           freight,
                                           shipname,
                                           shipaddress,
                                           shipcity,
                                           shipregion,
                                           shippostalcode,
                                           shipcountry
                                       FROM StoreSample.Sales.Orders
                                       WHERE orderid = @OrderId";

        public const string GetByCustomerId = @"SELECT
                                                   orderid,
                                                   custid,
                                                   empid,
                                                   orderdate,
                                                   requireddate,
                                                   shippeddate,
                                                   shipperid,
                                                   freight,
                                                   shipname,
                                                   shipaddress,
                                                   shipcity,
                                                   shipregion,
                                                   shippostalcode,
                                                   shipcountry
                                               FROM StoreSample.Sales.Orders
                                               WHERE custid = @CustId";

        public const string AddOrder = @"DECLARE @InsertedRecords TABLE (id INT);
                                         INSERT INTO Sales.Orders
                                         (
                                             custid,
                                             empid,
                                             orderdate,
                                             requireddate,
                                             shippeddate,
                                             shipperid,
                                             freight,
                                             shipname,
                                             shipaddress,
                                             shipcity,
                                             shipregion,
                                             shippostalcode,
                                             shipcountry
                                         )
                                         OUTPUT INSERTED.orderid INTO @InsertedRecords
                                         VALUES
                                         (
                                             @CustId,
                                             @EmpId,
                                             @OrderDate,
                                             @RequiredDate,
                                             @ShippedDate,
                                             @ShipperId,
                                             @Freight,
                                             @ShipName,
                                             @ShipAddress,
                                             @ShipCity,
                                             @ShipRegion,
                                             @ShipPostalCode,
                                             @ShipCountry
                                         )

                                         SELECT id FROM @InsertedRecords";
    }
}
