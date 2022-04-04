using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ZverGram.Db.Context.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.design.json")
                .Build();

            var options = new DbContextOptionsBuilder<MainDbContext>()
                .UseSqlServer(cfg.GetConnectionString("MainDbContext"),
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)).Options;
            return new MainDbContextFactory(options).Create();
        }
    }
}
