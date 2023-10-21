namespace SalesForecaster.Application.Utilities
{
    public class NextOrderDTO
    {
        public string CompanyName { get; set; }
        public DateTime LatestOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
