using System.Security.Claims;
using WebAPI.Models.Internal;

namespace WebAPI.Services.Tokenization;

public interface ITokenService
{
    string GenerateAccessToken(Users users);
    string  GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}