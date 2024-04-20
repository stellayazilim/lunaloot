using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Auth.Commands.Register;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Contracts.Auth.Register;

public record RegisterRequest()
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = null!;
    
    
    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = null!;
    
    
    [JsonPropertyName("email")] 
    public string Email { get;  init; } = null!;  
    
    
    [JsonPropertyName("password")] 
    public string Password { get; init; } = null!;  

    public static implicit operator RegisterRequest(RegisterCommand command)
    {
        return new RegisterRequest()
        {
          FirstName = command.FirstName,
          LastName = command.LastName,
          Email = command.Email,
          Password = command.Password
        };
    }

    public static implicit operator RegisterCommand(RegisterRequest request)
    {
        return new RegisterCommand(
            FirstName: request.FirstName,
            LastName: request.LastName,
            Email: request.Email,
            Password: request.Password);

    }
};