namespace SalesForecaster.Application.Utilities.Dtos.Order
{
    public class NextOrderDto
    {
        public int? custid { get; set; }
        public string customername { get; set; }
        public DateTime lastorderdate { get; set; }
        public DateTime nextpredictedorder { get; set; }
    }
}
