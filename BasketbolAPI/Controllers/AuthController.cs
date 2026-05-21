using BasketbolAPI.DTOs;
using BasketbolAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasketbolAPI.Controllers;

/// <summary>
/// Kullanıcı kayıt ve giriş işlemleri.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    /// <summary>
    /// Yeni kullanıcı kaydı oluşturur.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        var success = await _authRepository.RegisterAsync(userRegisterDto);
        if (!success)
            return BadRequest(new { message = "Bu kullanıcı adı zaten kullanılıyor." });

        return Ok(new { message = "Kayıt başarılı." });
    }

    /// <summary>
    /// Kullanıcı girişi yapar ve JWT token döner.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var token = await _authRepository.LoginAsync(userLoginDto);
        if (token is null)
            return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre." });

        return Ok(new { token });
    }
}
