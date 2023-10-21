using Microsoft.OpenApi.Models;
using System.Reflection;

namespace SalesForecaster.Presentation.API.Services
{
    public static class SwaggerService
    {
        public static void ConfigureApiDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Order Forecaster",
                    Version = "1.0.0",
                    Description = "API DOCUMENTATION"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
