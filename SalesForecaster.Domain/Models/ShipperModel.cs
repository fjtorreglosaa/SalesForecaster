namespace SalesForecaster.Domain.Models
{
    public class ShipperModel : IModel
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
