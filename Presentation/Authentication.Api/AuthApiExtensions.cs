using App.Persistence.AuthDataLayer;

namespace Authentication.Api
{
    public static class AuthApiExtensions
    {
        public static void AddAuthExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string 'DefaultConnection' not found.");
            }
            services.AddAuthDataLayer(connectionString);
        }
    }
}
