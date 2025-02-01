using KanesKitchenServer.DTOs.Users;
using KanesKitchenServer.Models;
using KanesKitchenServer.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IUserManagment
    {
        Task<GeneralResponse> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponse> LoginAsync (LoginDto loginDto);
        Task<LoginResponse> LoginViaRefreshTokenAsync(RefreshTokenDto refreshTokenDto);

    }
}
