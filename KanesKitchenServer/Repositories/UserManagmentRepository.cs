using KanesKitchenServer.Data;
using SharedLibrary.DTOs.Users;
using KanesKitchenServer.Interfaces;
using SharedLibrary.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using SharedLibrary.Models.Users;

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
            if (loginDto == null)
            {
                return new LoginResponse(false, "LoginDto is null");
            }

            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

            if (user == null)
            {
                return new LoginResponse(false, "User with this username and password combination does not exist");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new LoginResponse(false, "User with this username and password combination does not exist");
            }

            Roles role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);

            if (role == null)
            {
                return new LoginResponse(false, "Role does not exist");
            }

            string token = GenerateJwtToken(user, role.Role);
            string refreshToken = GenrateRefreshToken();

            RefreshToken refreshTokenFoundByUserId = await _context.RefreshTokens.FirstOrDefaultAsync(u => u.UserId == user.Id);

            if (refreshTokenFoundByUserId != null)
            {
                refreshTokenFoundByUserId.Token = refreshToken;
                await _context.SaveChangesAsync();
            }

            await _context.RefreshTokens.AddAsync(new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id
            });

            await _context.SaveChangesAsync();

            return new LoginResponse(true, "Login successful", token, refreshToken);

        }

        public async Task<LoginResponse> LoginViaRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            if (refreshTokenDto == null)
            {
                return new LoginResponse(false, "RefreshToken is null");
            }

            RefreshToken existingRefreshToken = _context.RefreshTokens.FirstOrDefault(r => r.Token == refreshTokenDto.Token);

            if (existingRefreshToken == null)
            {
                return new LoginResponse(false, "RefreshToken does not exist");
            }

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == existingRefreshToken.UserId);

            if (user == null)
            {
                return new LoginResponse(false, "User does not exist");
            }

            Roles role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);

            if (role == null)
            {
                return new LoginResponse(false, "Role does not exist");
            }

            string token = GenerateJwtToken(user, role.Role);
            string newRefreshToken = GenrateRefreshToken();

            existingRefreshToken.Token = newRefreshToken;
            await _context.SaveChangesAsync();

            return new LoginResponse(true, "Token refreshed successfully", token, newRefreshToken);

        }

        private string GenerateJwtToken(User user, String role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSelection.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSelection.Value.Issuer,
                audience: _jwtSelection.Value.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private string GenrateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public async Task<GeneralResponse> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return new GeneralResponse(false, "RegisterDto is null");
            }

            User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);

            if (existingUser != null)
            {
                return new GeneralResponse(false, "User with this email already exists");
            }

            existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == registerDto.UserName);

            if (existingUser != null)
            {
                return new GeneralResponse(false, "User with this username already exists");
            }

            await _context.Users.AddAsync(
                new User{
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    RoleId = 2
                }
            );

            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "User registered successfully");
        }
    }
}
