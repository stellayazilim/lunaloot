using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Infrastructure.Identity.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using JsonClaimValueTypes = Microsoft.IdentityModel.JsonWebTokens.JsonClaimValueTypes;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public record JwtRoleClaimItem(
    Guid Id,
    string Name,
    string? Description,
    ushort Weight,
    Permissions Permissions
);

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings) : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;


    public string GenerateToken(IdentityUser user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );


        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email.ToString()),
            new Claim("RoleCount", user.Roles.Count.ToString()),
            new Claim("Roles", JsonConvert.SerializeObject(
                user.Roles.Select(x => new JwtRoleClaimItem(
                    x.Id.Value,
                    x.Name,
                    x.Description,
                    x.Weight,
                    x.Permissions
                )),
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }), JsonClaimValueTypes.JsonArray)
        ];

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: dateTimeProvider.UtcNow.AddDays(1),
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}