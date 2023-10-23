using SalesForecaster.Application.Utilities.Dtos.OrderDetail;

namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class GetOrderDto
    {
        public int id { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public List<GetOrderDetailDto> OrderDetails { get; set; } = new List<GetOrderDetailDto>();
    }
}
