using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Contracts.Auth.Login;

public record LoginRequest()
{
    [JsonPropertyName("email")] 
    public string Email { get; init; } = null!;


    [JsonPropertyName("password")]
    public string Password { get; init; } = null!;

    public static implicit operator LoginWithCredentialsQuery(LoginRequest request)
    {
        return new LoginWithCredentialsQuery(
            Email: request.Email,
            Password: request.Password);
    }

    public static implicit operator LoginRequest(LoginWithCredentialsQuery withPasswordQuery)
    {
        return new LoginRequest()
        {
            Email = withPasswordQuery.Email,
            Password = withPasswordQuery.Password
        };

    }
}