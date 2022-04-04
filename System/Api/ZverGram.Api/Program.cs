
using Serilog;
using ZverGram.Api;
using ZverGram.Api.Configuration;
using ZverGram.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((host, cfg) =>
{
    cfg.ReadFrom.Configuration(host.Configuration);
});

var settings = new ApiSettings(new SettingsSource());

// Add services to the container.
var services = builder.Services;

services
    .AddHttpContextAccessor()
    .AddControllers().AddValdator();
services
    .AddHealthCheck()
    .AddAppDbContext(settings);
services
    .AddAppVersions()
    .AddAppSwagger(settings)
    .AddAppServices();
services.AddAutoMappers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles().UseRouting();
app.UseHealthCheck()
    .UseSerilogRequestLogging()
    .UseAuthorization();
app.UseAppSwagger();
app.UseAppDbContext();
app.MapControllers();
app.UseMiddleware();

app.Run();
