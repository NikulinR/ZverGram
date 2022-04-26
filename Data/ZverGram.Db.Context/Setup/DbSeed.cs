using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZverGram.Db.Context
{
    public static class DbSeed
    {
        private static void AddTestExhibitions(MainDbContext context)
        {
            if (context.Categories.Any() || context.Exhibitions.Any())
                return;

            var c1 = new Entities.Category { Name = "Dogs" };
            var c2 = new Entities.Category { Name = "Cats" };
            var c3 = new Entities.Category { Name = "Mixed" };

            context.Categories.Add(c1);
            context.Categories.Add(c2);


            var e1 = new Entities.Exhibition { Name = "Fancy dogs", Description = "Good Boys", Category = c1 };
            var e2 = new Entities.Exhibition { Name = "Pretty cats", Description = "They are so good", Category = c2 };
            var e3 = new Entities.Exhibition { Name = "Everybody", Description = "Cats and dogs", Category = c3 };

            context.Exhibitions.Add(e1);
            context.Exhibitions.Add(e2);
            context.Exhibitions.Add(e3);

            context.SaveChanges();
        }
        private static void AddTestUsers(MainDbContext context)
        {
            if (context.Users.Any())
                return;

            var u1 = new Entities.User()
            {
                UserName = "Su"
            };
            context.Users.Add(u1);

            var c1 = new Entities.Comment()
            {
                Author = u1,
                Content = "haha good",
                Exhibition = context.Exhibitions.FirstOrDefault(),
                Rating = 2
            };
            context.Comments.Add(c1);
            context.SaveChanges();
        }
        

        public static void Execute(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
            ArgumentNullException.ThrowIfNull(scope);

            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
            using var context = factory.CreateDbContext();
            AddTestExhibitions(context);
            AddTestUsers(context);
            //context.Category.Add();
            //context.SaveChanges();

        }
    }
}
