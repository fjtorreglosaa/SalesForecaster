using SalesForecaster.Application.Utilities.Dtos.OrderDetail;

namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public List<GetOrderDetailDto> OrderDetails { get; set; } = new List<GetOrderDetailDto>();
    }
}
