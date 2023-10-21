namespace SalesForecaster.Application.Utilities.Dtos.OrderDetail
{
    public class GetOrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Qty { get; set; }
        public int Discount { get; set; }
    }
}
