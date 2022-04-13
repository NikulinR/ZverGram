using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.CommentService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddCommentService(this IServiceCollection service)
        {
            service.AddSingleton<ICommentService, CommentService>();
            return service;
        }
    }
}
