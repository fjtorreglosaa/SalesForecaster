namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class NextOrderDto
    {
        public string CompanyName { get; set; }
        public DateTime LatestOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
