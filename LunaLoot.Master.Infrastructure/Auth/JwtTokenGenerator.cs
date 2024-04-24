using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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
            new Claim("RoleCount", user.Roles.Count.ToString()),
            new Claim("Roles", JsonConvert.SerializeObject(
                user.Roles, 
                Formatting.Indented,
                new JsonSerializerSettings() {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    
                }), JsonClaimValueTypes.JsonArray)
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