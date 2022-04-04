using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.Db.Context
{
    public static class DbSeed
    {
        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
            ArgumentNullException.ThrowIfNull(scope);

            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
            using var context = factory.CreateDbContext();

            //context.Category.Add();
            //context.SaveChanges();

        }
    }
}
