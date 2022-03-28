using Serilog;
using ZverGram.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((host, cfg) =>
{
    cfg.ReadFrom.Configuration(host.Configuration);
});

// Add services to the container.
var services = builder.Services;

services.AddControllers();
services.AddHealthCheck();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHealthCheck();
app.UseAuthorization();
 
app.MapControllers();

app.Run();
