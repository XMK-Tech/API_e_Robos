using ItoApi.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
IServiceCollection services = builder.Services;

var startup = new Startup(configuration);
startup.ConfigureServices(services);

var app = builder.Build();
startup.Configure(app, environment);

// Home controller
app.MapGet("", () => Results.Ok());

app.Run();