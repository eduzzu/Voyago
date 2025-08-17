using Voyago_Backend.Models;

namespace Voyago_Backend.Services
{
    public interface IAuthService
    {
    Task<User?> Register(RegisterDto request);
    Task<TokenResponse?> Login(LoginDto request);
    Task<TokenResponse?> RefreshTokens(RefreshTokenRequest request);
    Task<bool> SendResetPasswordEmail(string email);

    Task<bool> ResetPassword(string token, string newPassword);
}
    }
