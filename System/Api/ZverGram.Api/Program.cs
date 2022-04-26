
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
    .AddAppDbContext(settings)
    .AddHealthCheck()
    .AddAppVersions()
    .AddAppSwagger(settings)
    .AddAppCors()
    .AddAppServices();
services
    .AddAppAuth(settings)
    .AddControllers()
    .AddValidator();
services
    .AddAutoMappers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware();
app.UseStaticFiles().UseRouting();
app.UseAppCors();
app.UseHealthCheck()
   .UseSerilogRequestLogging();
app.UseAppSwagger();

app.UseAppAuth();
//app.UseAuthorization();

app.MapControllers();
app.UseAppDbContext();

app.Run();
