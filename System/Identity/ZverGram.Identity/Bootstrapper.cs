using ZverGram.Settings;

namespace ZverGram.Identity
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services
                .AddSettings();
        }
    }
}
