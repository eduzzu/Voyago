using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Voyago_Backend.Data;
using Voyago_Backend.Models;

namespace Voyago_Backend.Services
{
    public class AuthService(AppDbContext appDbContext, TokenGeneratorService tokenGeneratorService, IEmailService emailService) : IAuthService
    {
        public async Task<TokenResponse?> Login(LoginDto request)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) return null;
            if (!user.VerifyPassword(request.Password))
            {
                return null;
            }
            return await CreateTokenResponse(user);
        }

        private async Task<TokenResponse> CreateTokenResponse(User user)
        {
            return new TokenResponse
            {
                AccessToken = tokenGeneratorService.GenerateToken(user.UserId, user.Email),
                RefreshToken = await GenerateAndSaveRefreshToken(user)
            };
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await appDbContext.SaveChangesAsync();
            return refreshToken;
        }

        private async Task<User?> ValidateRefreshToken(Guid userId, string refreshToken)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.RefreshToken == refreshToken);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return null;
            }

            return user;
        }

        public async Task<TokenResponse?> RefreshTokens(RefreshTokenRequest request)
        {
            var user = await ValidateRefreshToken(request.UserId, request.RefreshToken);
            if (user is null) return null;
            return await CreateTokenResponse(user);
        }

        public async Task<bool> SendResetPasswordEmail(string email)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            user.ResetPasswordToken = Guid.NewGuid().ToString();
            user.ResetPasswordTokenExpires = DateTime.UtcNow.AddHours(1);

            await appDbContext.SaveChangesAsync();

            var resetLink = $"http://localhost:5001/auth/reset-password?token={user.ResetPasswordToken}";
            var emailBody = $"Click <a href='{resetLink}'>here</a> to change your password. This link expires in an hour. Do not share this link with anyone.";

            await emailService.SendEmail(user.Email, "Reset Password", emailBody);

            return true;
        }

        public async Task<bool> ResetPassword(string token, string newPassword)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u =>
                u.ResetPasswordToken == token && u.ResetPasswordTokenExpires > DateTime.UtcNow);

            if (user == null)
                return false;

            user.SetPassword(newPassword);
            user.ResetPasswordToken = null;
            user.ResetPasswordTokenExpires = null;

            await appDbContext.SaveChangesAsync();

            return true;
        }
        public async Task<User?> Register(RegisterDto request)
        {
            if (await appDbContext.Users.AnyAsync(user => user.Email == request.Email))
            {
                return null;
            }
            User newUser;

            if (request.AccountType == "Owner")
            {
                newUser = new Owner();
            }
            else if (request.AccountType == "Driver")
            {
                newUser = new Driver();
            }
            else if (request.AccountType == "Admin")
            {
                newUser = new Admin();
            }
            else
            {
                newUser = new User();
            }

            newUser.FirstName = request.FirstName;
            newUser.LastName = request.LastName;
            newUser.Email = request.Email;
            newUser.SetPassword(request.Password);
            newUser.DateOfBirth = request.DateOfBirth;
            newUser.PhoneNumber = request.PhoneNumber;

            appDbContext.Users.Add(newUser);
            await appDbContext.SaveChangesAsync();
            return newUser;
        }
    }
}