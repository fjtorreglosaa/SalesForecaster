namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class SupplierSQL
    {
        public const string GetAll = @"SELECT 
											supplierid,
											companyname,
											contactname,
											contacttitle,
											address,
											city,
											region,
											postalcode,
											country,
											phone,
											fax
										FROM StoreSample.Production.Suppliers";

        public const string GetById = @"SELECT 
											supplierid,
											companyname,
											contactname,
											contacttitle,
											address,
											city,
											region,
											postalcode,
											country,
											phone,
											fax
										FROM StoreSample.Production.Suppliers
										WHERE supplierid = @SupplierId";
    }
}
