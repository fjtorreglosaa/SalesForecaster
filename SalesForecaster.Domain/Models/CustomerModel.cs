namespace SalesForecaster.Domain.Models
{
    public class CustomerModel : IModel
    {
        public int CustId { get; set; }
        public int CompanyName { get; set; }
        public string ContactName { get; set; }
        public int ContactTitle { get; set; }
        public int Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
    }
}
