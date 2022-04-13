using ZverGram.Db.Context;
using ZverGram.Settings;

namespace ZverGram.Identity.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IDbSettings settings)
        {
            var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString);

            services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

            return services;
        }

        public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
