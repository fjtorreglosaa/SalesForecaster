namespace SalesForecaster.Application.Utilities
{
    public class ResultModel<T>
    {
        public ResultModel() { }
        public ResultModel(T data, string message = null)
        {
            Data = data;
            Message = message;
        }

        public T Data { get; set; }
        public bool Error { get; set; } = false;
        public string? Message { get; set; }
        public int? Total { get; set; } = 0;
        public int? PageCount { get; set; } = 0;

        public static ResultModel<List<T>> GetResultModel(List<T> data, int allRecords, string message = null, int recordsPerPage = 10)
        {
            var result = new ResultModel<List<T>>(data, message)
            {
                Total = data.Any() ? allRecords : 0,
                PageCount = data.Any() ? (int)Math.Ceiling((double)allRecords / recordsPerPage) : 0
            };
            return result;
        }

        public static ResultModel<T> GetResultModel(T data, string message = null)
        {
            var result = new ResultModel<T>(data, message)
            {
                Total = 1,
                PageCount = 1
            };
            return result;
        }
    }
}
