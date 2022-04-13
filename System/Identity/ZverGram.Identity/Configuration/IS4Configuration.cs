using Microsoft.AspNetCore.Identity;
using ZverGram.Db.Context;
using ZverGram.Db.Entities;
using ZverGram.Identity.Configuration.IS4;

namespace ZverGram.Identity.Configuration
{
    public static class IS4Configuration
    {
        public static IServiceCollection AddIS4(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole<Guid>>(opt =>
                {
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<MainDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddInMemoryApiScopes(AppApiScopes.ApiScopes)
                .AddInMemoryClients(AppClients.Clients)
                .AddInMemoryApiResources(AppResources.Resources)
                .AddInMemoryIdentityResources(AppIdentityResources.Resources)
                .AddTestUsers(AppApiTestUsers.ApiUsers)
                //todo сгенерировать сертификат вручную
                .AddDeveloperSigningCredential();

            return services;
        }

        public static WebApplication UseIS4(this WebApplication app)
        {
            app.UseIdentityServer();
            return app;
        }
    }
}
