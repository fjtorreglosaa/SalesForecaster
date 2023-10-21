namespace SalesForecaster.Domain.Models
{
    public class CategoryModel : IModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
