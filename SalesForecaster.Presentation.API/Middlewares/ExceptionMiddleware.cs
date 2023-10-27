using Newtonsoft.Json;
using SalesForecaster.Application.Exceptions;
using SalesForecaster.Presentation.API.Errors;
using System.Net;

namespace SalesForecaster.Presentation.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;
                var errorMessage = "No details for this request. Please contact support.";

                switch (ex)
                {
                    case NotFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case EntityException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                        break;
                    case BadRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = !(_env.EnvironmentName == "LIVE")
                        ? JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace))
                        : JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, errorMessage));
                }

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
