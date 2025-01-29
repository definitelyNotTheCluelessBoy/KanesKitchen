using KanesKitchenServer.Models.Users;

namespace KanesKitchenServer.Interfaces
{
    public interface IUserAccount
    {
        Task<User> CreateUserAsync(int id);
        Task<User> LogInAsync(int id);
    }
}
