using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ZverGram.Web
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<AuthenticationState> GetState() {
            return await authenticationStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var url = $"{Settings.IdentityRoot}/connect/token";
            var request_body = new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_id", Settings.ClientId),
                new KeyValuePair<string, string>("client_secret", Settings.ClientSecret),
                new KeyValuePair<string, string>("username", loginModel.Email!),
                new KeyValuePair<string, string>("password", loginModel.Password!)
            };

            var requestContent = new FormUrlEncodedContent(request_body);

            var response = await httpClient.PostAsync(url, requestContent);

            var content = await response.Content.ReadAsStringAsync();

            var loginResult = JsonSerializer.Deserialize<LoginResult>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new LoginResult();
            loginResult.Successful = response.IsSuccessStatusCode;

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await localStorage.SetItemAsync("authToken", loginResult.AccessToken);
            await localStorage.SetItemAsync("refreshToken", loginResult.RefreshToken);

            ((AuthStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email!);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.AccessToken);

            return loginResult;
        }

        public async Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
