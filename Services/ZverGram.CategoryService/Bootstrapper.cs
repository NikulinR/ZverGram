using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.CategoryService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCategoryService(this IServiceCollection service)
        {
            service.AddSingleton<ICategoryService, CategoryService>();
            return service;
        }
    }
}
