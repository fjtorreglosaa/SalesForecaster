using SalesForecaster.Application.Utilities.Dtos.OrderDetail;

namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class AddOrderDto
    {
        public int? EmployeeId { get; set; }
        public int? CustId { get; set; }
        public int? ShipperId { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipCountry { get; set; }
        public List<GetOrderDetailDto> OrderDetails { get; set; } = new List<GetOrderDetailDto>();
    }
}
