using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.Settings
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSettings(this IServiceCollection services)
        {
            services.AddSingleton<ISettingsSource, SettingsSource>();
            services.AddSingleton<IApiSettings, ApiSettings>();
            services.AddSingleton<IIdentitySettings, IdentitySettings>();
            services.AddSingleton<IGeneralSettings, GeneralSettings>();
            services.AddSingleton<IDbSettings, DbSettings>();
            return services;
        }
    }
}
