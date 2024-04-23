using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

namespace LunaLoot.Master.Contracts.Auth.Login;

public struct LoginResponse
{
    [JsonPropertyName("email")] public string Email { get; init; }


    [JsonPropertyName("accessToken")] public string Token { get; init; }


    public static implicit operator LoginResponse(LoginWithPasswordQueryResult result)
    {

        return new LoginResponse()
        {
            Email = result.User.Email,
            Token = result.Token
        };
    }
    
}