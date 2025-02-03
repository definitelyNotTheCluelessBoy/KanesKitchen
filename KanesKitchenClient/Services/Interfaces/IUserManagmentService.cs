using SharedLibrary.DTOs.Users;
using SharedLibrary.Responses;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IUserManagmentService
    {
        Task<GeneralResponse> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponse> LoginAsync(LoginDto loginRequest);
        Task<LoginResponse> LoginViaRefreshTokenAsync(RefreshTokenDto refreshTokenDto);

    }
}
