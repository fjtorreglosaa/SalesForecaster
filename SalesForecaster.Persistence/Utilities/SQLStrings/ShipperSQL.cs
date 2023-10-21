namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class ShipperSQL
    {
        public const string GetAll = @"SELECT 
                                            shipperid, 
                                            companyname, 
                                            phone 
                                        FROM StoreSample.Sales.Shippers";

        public const string GetById = @"SELECT 
                                            shipperid, 
                                            companyname, 
                                            phone 
                                        FROM StoreSample.Sales.Shippers
                                        WHRERE shipperid = @ShipperId";
    }
}
