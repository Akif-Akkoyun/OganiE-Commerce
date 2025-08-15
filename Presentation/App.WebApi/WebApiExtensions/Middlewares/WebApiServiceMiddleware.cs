namespace App.WebApi.WebApiExtensions.Middlewares
{
    public static class WebApiServiceMiddleware
    {
        public static IApplicationBuilder UseWebApiService(this WebApplication app)
        {
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            return app;
        }
    }
}
