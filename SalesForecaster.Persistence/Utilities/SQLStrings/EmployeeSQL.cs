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

       // public const string GetEmployeeFiltered = @"SELECT Empid, firstname, lastname, address, city, country, phone FROM StoreSample.HR.Employees WHERE firstname LIKE @parameter";


        public const string GetEmployeeFiltered = @"SELECT 
                                            Empid, 
                                            firstname, 
                                      FROM  StoreSample.HR.Employees
                                      WHRERE firstname = @parameter";
    }
}
