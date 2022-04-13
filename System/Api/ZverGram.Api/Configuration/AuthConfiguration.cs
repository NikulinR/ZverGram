namespace ZverGram.API.Configuration;

using ZverGram.Common.Security;
using Microsoft.Extensions.DependencyInjection;
using ZverGram.Settings;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ZverGram.Db.Context;
using ZverGram.Db.Entities;
using Microsoft.IdentityModel.Logging;

public static class AuthConfiguration
{
    public static IServiceCollection AddAppAuth(this IServiceCollection services, IApiSettings settings)
    {
        IdentityModelEventSource.ShowPII = true;
        services
            .AddIdentity<User, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequiredLength = 0;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = settings.IdentityServer.RequireHttps;
                options.Authority = "http://localhost:5167";//  settings.IdentityServer.Url; //
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Audience = "api";
            });


        services.AddAuthorization(options =>
        {
            options.AddPolicy(AppScopes.ExhibitionsRead, policy => policy.RequireClaim("scope", AppScopes.ExhibitionsRead));
            options.AddPolicy(AppScopes.ExhibitionsWrite, policy => policy.RequireClaim("scope", AppScopes.ExhibitionsWrite));

            options.AddPolicy(AppScopes.CommentsRead, policy => policy.RequireClaim("scope", AppScopes.CommentsRead));
            options.AddPolicy(AppScopes.CommentsWrite, policy => policy.RequireClaim("scope", AppScopes.CommentsWrite));

            options.AddPolicy(AppScopes.CategoriesRead, policy => policy.RequireClaim("scope", AppScopes.CategoriesRead));
            options.AddPolicy(AppScopes.CategoriesWrite, policy => policy.RequireClaim("scope", AppScopes.CategoriesWrite));
        });

        return services;
    }

    public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();

        app.UseAuthorization();

        return app;
    }
}