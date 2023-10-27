namespace SalesForecaster.Presentation.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "There are errors in the provided request",
                401 => "User is not authorized for the requested resource",
                404 => "User does not have permissions for the requested resource",
                500 => "There are errors in the server",
                _ => string.Empty
            };
        }
    }
}
