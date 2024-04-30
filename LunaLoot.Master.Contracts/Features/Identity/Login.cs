using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Features.Identity.Queries.Login;
using LunaLoot.Master.Domain.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Contracts.Features.Identity;

public record LoginRequest
{

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;


    public static explicit operator LoginQuery(LoginRequest request)
    {
        return new(
            Email: request.Email,
            Password:request.Password
            );
    }
    
};


public record LoginResponse
{
    [JsonPropertyName("user")]
    public LoginResponseUser User { get; set; }
    
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
    

    public  IActionResult ToActionResult(LoginQueryResult result)
    {
        return new OkObjectResult(new LoginResponse()
        {   
            User = result.User,
            AccessToken = result.AccessToken,
            RefreshToken = result.RefreshToken
        });
    }
}



public record LoginResponseUser
{
    [JsonPropertyName("id")]
    public Guid UserId { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;


    [JsonPropertyName("phone")]
    public string PhoneNumber { get; init; } = string.Empty;
    
    
    public static implicit operator LoginResponseUser(IdentityUser user)
    {
        return new LoginResponseUser() 
        {
            UserId = user.Id.Value,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
    
}