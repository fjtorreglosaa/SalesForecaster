namespace SalesForecaster.Persistence.Utilities.SQLStrings
{
    public class EmployeeSQL
    {
        public const string GetAll = @"SELECT 
                                            empid, 
                                            lastname, 
                                            firstname, 
                                            title, 
                                            titleofcourtesy, 
                                            birthdate, 
                                            hiredate, 
                                            address, 
                                            city, 
                                            region, 
                                            postalcode, 
                                            country, 
                                            phone, 
                                            mgrid 
                                       FROM StoreSample.HR.Employees";

        public const string GetById = @"SELECT 
                                            empid, 
                                            lastname, 
                                            firstname, 
                                            title, 
                                            titleofcourtesy, 
                                            birthdate, 
                                            hiredate, 
                                            address, 
                                            city, 
                                            region, 
                                            postalcode, 
                                            country, 
                                            phone, 
                                            mgrid
                                       FROM StoreSample.HR.Employees
                                       WHERE empid = @EmpId";
    }
}
