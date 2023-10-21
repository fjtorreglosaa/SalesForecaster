namespace SalesForecaster.Domain.Models
{
    public class OrderDetailModel : IModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
