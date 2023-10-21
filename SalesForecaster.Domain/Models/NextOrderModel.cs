namespace SalesForecaster.Domain.Models
{
    public class NextOrderModel : IModel
    {
        public string CompanyName { get; set; }
        public DateTime LatestOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}