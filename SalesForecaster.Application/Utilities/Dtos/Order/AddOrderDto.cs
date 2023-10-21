namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class AddOrderDto
    {
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
