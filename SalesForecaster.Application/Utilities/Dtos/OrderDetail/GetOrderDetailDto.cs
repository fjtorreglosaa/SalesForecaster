namespace SalesForecaster.Application.Utilities.Dtos.OrderDetail
{
    public class GetOrderDetailDto
    {
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Qty { get; set; }
        public decimal? Discount { get; set; }
    }
}
