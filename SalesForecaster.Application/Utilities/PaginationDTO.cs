namespace SalesForecaster.Application.Utilities
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 25;

        public int RecordsPerPage
        {
            get { return recordsPerPage; }
            set { recordsPerPage = value > maxRecordsPerPage ? maxRecordsPerPage : value; }
        }
    }
}
