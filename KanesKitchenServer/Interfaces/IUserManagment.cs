using KanesKitchenServer.DTOs.Users;
using KanesKitchenServer.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IUserManagment
    {
        Task<GeneralResponse> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponse> LoginAsync (LoginDto loginDto);

    }
}
