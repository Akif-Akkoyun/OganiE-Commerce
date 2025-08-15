using App.WebApi.WebApiExtensions.Extensions;
using App.WebApi.WebApiExtensions.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWebApiService();

await app.RunAsync();