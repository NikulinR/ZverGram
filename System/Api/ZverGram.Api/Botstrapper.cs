using ZverGram.CategoryService;
using ZverGram.CommentService;
using ZverGram.ExhibitionService;
using ZverGram.Settings;

namespace ZverGram.Api
{
    public static class Botstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services
                .AddSettings()
                .AddExhibitionService()
                .AddCategoryService()
                .AddCommentService();

        }
    }
}
