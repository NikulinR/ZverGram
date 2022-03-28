namespace ZverGram.Api.Configuration
{
    public static class HealthCheckConfiguration
    { 
        public static IServiceCollection AddHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<ApiHealthCheck>("ZverGram.Api");
            return services;
        }

        public static WebApplication UseHealthCheck(this WebApplication app)
        {
            app.MapHealthChecks("/health");
            return app;
        }
    }
}
