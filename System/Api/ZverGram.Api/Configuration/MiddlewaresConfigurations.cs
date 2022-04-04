using ZverGram.Api.Middlewares;

namespace ZverGram.Api.Configuration
{
    public static class MiddlewaresConfigurations
    {
        
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleLayer>();
            return app;
        }
    }
}
