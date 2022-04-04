
using ZverGram.Common.Helpers;

namespace ZverGram.Api.Configuration
{
    public static class MapperConfigurations
    {
        
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            AutoMapperRegisterHelper.Register(services);
            return services;
        }
    }
}
