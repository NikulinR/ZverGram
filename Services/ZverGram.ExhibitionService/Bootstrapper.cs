using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.ExhibitionService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddExhibitionService(this IServiceCollection service)
        {
            service.AddSingleton<IExhibitionService, ExhibitionService>();
            return service;
        }
    }
}
