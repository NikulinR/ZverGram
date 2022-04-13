using ZverGram.Identity;
using ZverGram.Identity.Configuration;
using ZverGram.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure application

var settings = new IS4Settings(new SettingsSource());

// Configure services
var services = builder.Services;

services.AddAppCors();
services.AddAppDbContext(settings.Db);
services.AddHttpContextAccessor();
services.AddAppServices();
services.AddIS4();

// Start application
var app = builder.Build();

app.UseAppCors();
app.UseStaticFiles();
app.UseRouting();
app.UseAppDbContext();
app.UseIS4();

app.Run();