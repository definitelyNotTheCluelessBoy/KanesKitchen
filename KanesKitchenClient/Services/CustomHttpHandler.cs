using KanesKitchenClient.Services.Implementations;
using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.Users;
using System.Net;
using System.Net.Http.Headers;

namespace KanesKitchenClient.Services
{
    public class CustomHttpHandler : DelegatingHandler
    {
        private readonly LocalStorageService _localStorageService;
        private readonly Session _session;
        private readonly IUserManagmentService _userManagmentService;
        public CustomHttpHandler(LocalStorageService localStorageService, Session session, IUserManagmentService userManagmentService)
        {
            _localStorageService = localStorageService;
            _session = session;
            _userManagmentService = userManagmentService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            bool loginUrl = request.RequestUri.AbsoluteUri.Contains("login");
            bool loginViaRefreshTokenUrl = request.RequestUri.AbsoluteUri.Contains("loginViaRefreshToken");
            bool registerUrl = request.RequestUri.AbsoluteUri.Contains("register");

            if (loginUrl || loginViaRefreshTokenUrl || registerUrl)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var result = await base.SendAsync(request, cancellationToken);

            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshToken = await _localStorageService.GetToken();
                if (refreshToken == null)
                {
                    return result;
                }

                string token = "";

                try
                {
                    var deserialized = Serialization.Deserialize<Session>(refreshToken);
                    if (deserialized == null)
                    {
                        return result;
                    }
                    token = deserialized.RefreshToken;
                }
                catch (Exception)
                {
                    return result;
                }

                if (token == null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return await base.SendAsync(request, cancellationToken);
                }

                var newRefreshToken = await GetNewRefreshToken(token);
                if (newRefreshToken == null)
                {
                    return result;
                }

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newRefreshToken);
                return await base.SendAsync(request, cancellationToken);
            }
            return result;
        }

        private async Task<string> GetNewRefreshToken(string token)
        {
            var result = await _userManagmentService.LoginViaRefreshTokenAsync(new RefreshTokenDto() { Token = token });
            if (result.Success)
            {
                string serializedToken = Serialization.Serialize(new Session() { Token = result.Token, RefreshToken = result.RefreshToken });
                return result.Token;
            }
            else
            {
                await _localStorageService.RemoveToken();
                return null;
            }
        }
    }
}
