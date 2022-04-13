namespace ZverGram.Identity.Configuration.IS4;

using Duende.IdentityServer.Models;
using ZverGram.Common.Security;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.ExhibitionsRead, "Access to exhibitions API - Read data"),
            new ApiScope(AppScopes.ExhibitionsWrite, "Access to exhibitions API - Write data"),
            new ApiScope(AppScopes.CommentsRead, "Access to comments API - Read data"),
            new ApiScope(AppScopes.CommentsWrite, "Access to comments API - Write data"),
            new ApiScope(AppScopes.CategoriesRead, "Access to categories API - Read data"),
            new ApiScope(AppScopes.CategoriesWrite, "Access to categories API - Write data")
        };
}