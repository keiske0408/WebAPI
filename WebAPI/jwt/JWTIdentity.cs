using Microsoft.AspNetCore.Identity;

namespace WebAPI.jwt;

public class JWTIdentity : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}