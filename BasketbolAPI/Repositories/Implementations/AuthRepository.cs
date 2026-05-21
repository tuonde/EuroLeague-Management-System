using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BasketbolAPI.Data;
using BasketbolAPI.DTOs;
using BasketbolAPI.Models;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BasketbolAPI.Repositories.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<bool> RegisterAsync(UserRegisterDto userRegisterDto)
    {
        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == userRegisterDto.Username);

        if (usernameExists)
            return false;

        var user = new User
        {
            Username = userRegisterDto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
            Role = "Admin"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<string?> LoginAsync(UserLoginDto userLoginDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == userLoginDto.Username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.PasswordHash))
            return null;

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        var key = _configuration["Jwt:Key"]!;
        var issuer = _configuration["Jwt:Issuer"]!;
        var audience = _configuration["Jwt:Audience"]!;

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
