using Microsoft.AspNetCore.Mvc;

namespace ZverGram.Api.Configuration
{
    public static class VersioningConfiguration        
    {
        public static IServiceCollection AddAppVersions(this IServiceCollection service)
        {
            service.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });

            service.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

            return service;
        }

        public static IApplicationBuilder UseAppVersions(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
