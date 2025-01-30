using KanesKitchenServer.Data;
using KanesKitchenServer.DTOs.Users;
using KanesKitchenServer.Interfaces;
using KanesKitchenServer.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace KanesKitchenServer.Repositories
{
    public class UserManagmentRepository : IUserManagment
    {
        private readonly AppDBContext _context;
        private readonly IOptions<JwtSelection> _jwtSelection;

        public UserManagmentRepository(AppDBContext context , IOptions<JwtSelection> jwtSelection)
        {
            _context = context;
            _jwtSelection = jwtSelection;
        }

        public async Task<LoginResponse> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return new GeneralResponse(false, "RegisterDto is null");
            }


            throw new NotImplementedException();
        }
    }
}
