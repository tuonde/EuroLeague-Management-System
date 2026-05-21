using BasketbolAPI.DTOs;

namespace BasketbolAPI.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<bool> RegisterAsync(UserRegisterDto userRegisterDto);
    Task<string?> LoginAsync(UserLoginDto userLoginDto);
}
