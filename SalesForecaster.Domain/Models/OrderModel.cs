namespace SalesForecaster.Domain.Models
{
    public class OrderModel : IModel
    {
        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public int EmpId { get; set; }
        public DateTime OrderFate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippeDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
