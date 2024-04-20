using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Domain.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LunaLoot.Master.Infrastructure.Auth;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings) : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public string GenerateToken(ApplicationUser user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email.ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: dateTimeProvider.UtcNow.AddDays(1),
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}