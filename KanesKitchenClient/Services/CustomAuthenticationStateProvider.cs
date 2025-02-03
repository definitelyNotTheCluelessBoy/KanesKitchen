using SharedLibrary.Models.Users;
using KanesKitchenClient.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace KanesKitchenClient.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly LocalStorageService _localStorageService;
        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());


        public CustomAuthenticationStateProvider(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetToken();
            if (token == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var deserialized = Serialization.Deserialize<Session>(token);
            if (deserialized == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var userClaims = DecryptToken(deserialized.Token!);
            if (userClaims == null)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }

            var claimsPrincipal = SetClaimPrincipal(userClaims);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));


        }

        public async Task UpdateAuthenticationState(Session session)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (session.Token != null || session.RefreshToken != null)
            {
                var serializeSession = Serialization.Serialize(session);
                await _localStorageService.SaveToken(serializeSession);
                var userClaims = DecryptToken(session.Token);
                claimsPrincipal = SetClaimPrincipal(userClaims);
            }
            else 
            { 
                await _localStorageService.RemoveToken();
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));

        }

        private static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.UserName == null)
            {
                return new ClaimsPrincipal();
            }

            return new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, claims.Id),
                new Claim(ClaimTypes.Name, claims.UserName),
                new Claim(ClaimTypes.Email, claims.Email),
                new Claim(ClaimTypes.Role, claims.Role)
            }, "apiauth"));

        }

        private static CustomUserClaims DecryptToken(string jwt)
        {
            if(jwt == null)
            {
                return new CustomUserClaims();
            }

            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.ReadJwtToken(jwt);

            var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userName = token.Claims.FirstOrDefault(n => n.Type == ClaimTypes.Name);
            var email = token.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email);
            var role = token.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);

            return new CustomUserClaims(userId!.Value!, userName!.Value!, email!.Value!, role!.Value!);
        }
    }
}
