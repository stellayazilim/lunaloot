using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Features.Identity.Commands.RegisterUser;

namespace LunaLoot.Master.Contracts.Features.Identity;

public class RegisterRequest
{

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;
    
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;


    public static explicit operator RegisterUserCommand(RegisterRequest request)
    {
        return new (
            Email: request.Email,
            Password: request.Password,
            PhoneNumber: request.PhoneNumber
        );
    }
}