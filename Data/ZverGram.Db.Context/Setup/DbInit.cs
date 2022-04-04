using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.Db.Context
{
    public static class DbInit
    {
        public static void Execute(IServiceProvider serviceProvider)
        {
            while (true)
            {
                using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
                ArgumentNullException.ThrowIfNull(scope);

                var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
                using var context = factory.CreateDbContext();

                try
                {
                    context.Database.Migrate();
                    break;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(new TimeSpan(seconds: 5, hours:0, minutes:0));
                }
            }
            

        }
    }
}
