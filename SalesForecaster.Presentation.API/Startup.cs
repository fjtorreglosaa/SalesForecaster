using SalesForecaster.Application.Utilities;
using SalesForecaster.Persistence.UnitOfWork.Contracts;
using SalesForecaster.Persistence.UnitOfWork.DapperUnitOfWork;
using SalesForecaster.Presentation.API.Services;

namespace SalesForecaster.Presentation.API
{
    public class Startup
    {
        private const string ENVIRONMENT_LIVE = "LIVE";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddEndpointsApiExplorer();
            services.ConfigureApiDocumentation();
            services.ConfigureMediator();
            services.AddAutoMapper(typeof(Mappings));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsEnvironment(ENVIRONMENT_LIVE))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
