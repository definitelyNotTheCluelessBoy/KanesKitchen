using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.Users;
using SharedLibrary.Responses;
using System.Net.Http.Json;

namespace KanesKitchenClient.Services.Implementations
{
    public class UserManagmentService : IUserManagmentService
    {
        GetHttpClient _httpClient;
        public const string UserManagmentServiceRoute = "api/UserManagment";

        public UserManagmentService(GetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<LoginResponse> LoginAsync(LoginDto loginRequest)
        {
            var httpClient = _httpClient.GetPublicHttpClient().Result;
            var response = await httpClient.PostAsJsonAsync($"{UserManagmentServiceRoute}/login", loginRequest);
            if (!response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            };
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<LoginResponse> LoginViaRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            var httpClient = _httpClient.GetPublicHttpClient().Result;
            var response = await httpClient.PostAsJsonAsync($"{UserManagmentServiceRoute}/loginViaRefreshToken", refreshTokenDto);
            if (!response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            };
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<GeneralResponse> RegisterAsync(RegisterDto registerDto)
        {
            var httpClient = _httpClient.GetPublicHttpClient().Result;
            var response = await httpClient.PostAsJsonAsync($"{UserManagmentServiceRoute}/register", registerDto);
            if (!response.IsSuccessStatusCode) { 
                return await response.Content.ReadFromJsonAsync<GeneralResponse>();
            };
            return await response.Content.ReadFromJsonAsync<GeneralResponse>();

        }
    }
}
