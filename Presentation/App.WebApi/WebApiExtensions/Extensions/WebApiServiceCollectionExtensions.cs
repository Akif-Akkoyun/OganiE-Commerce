using App.Persistence.Extensions;

namespace App.WebApi.WebApiExtensions.Extensions
{
    public static class WebApiServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("ConnectionString NotFound");

            services.AddPersistenceServices(connectionString);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
