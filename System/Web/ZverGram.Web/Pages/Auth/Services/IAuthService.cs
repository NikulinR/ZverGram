using Microsoft.AspNetCore.Components.Authorization;

namespace ZverGram.Web
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<AuthenticationState> GetState();
    }
}
