namespace ZverGram.Identity.Configuration.IS4;

using Duende.IdentityServer.Models;
using ZverGram.Common.Security;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.AuthorisedUser, "Access to exhibitions API - Add comments"),
            new ApiScope(AppScopes.ContentMaker, "Access to exhibitions API - Add content"),
            new ApiScope(AppScopes.Moderator, "Access to exhibitions API - Delete content and comments")
        };
}