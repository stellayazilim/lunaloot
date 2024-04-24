using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;
using LunaLoot.Master.Domain.Address.ValueObjects;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
namespace LunaLoot.Master.Contracts.Auth.Login;

public struct LoginResponse
{
    [JsonPropertyName("user")] 
    public LoginResponseUser  User { get; set; }


    [JsonPropertyName("accessToken")] public string Token { get; init; }


    public static implicit operator LoginResponse(LoginWithPasswordQueryResult result)
    {

        return new LoginResponse()
        {
            User = result.User,
            Token = result.Token
        };
    }
}


public struct LoginResponseUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public Guid Id { get; set; }
    
    public IEnumerable<LoginResponseAddress> Addresses { get; set; }
    
    public IEnumerable<LoginResponseRoles> Roles { get; set; }

    public static implicit operator LoginResponseUser(ApplicationUser user)
    {
        return new LoginResponseUser()
        {
            Id = user.Id.Value,
            FirstName = user.FirstName,
            LastName =  user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Addresses = user.Addresses.ToList().ConvertAll<LoginResponseAddress>(x =>
            {
                var addr = new LoginResponseAddress();

                addr = x;
                return addr;
            }),
            Roles = user.Roles.ToList().ConvertAll(x =>
            {
                var role = new LoginResponseRoles();
                role = x;
                return role;
            })
        };
    }
}

public record LoginResponseAddress
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; }

    public static implicit operator LoginResponseAddress(AddressId address)
    {
        return new LoginResponseAddress()
        {
            Id = address.Value,
            Endpoint = $"/address/{address.Value}"
        };
    }

}

public record LoginResponseRoles
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("weight")]
    public byte Weight { get; set; }

    [JsonPropertyName("perms")] 
    public IEnumerable<string> Perms { get; set; }

    public static implicit operator LoginResponseRoles(ApplicationRole role)
    {
        return new LoginResponseRoles()
        {
            Id = role.Id.Value,
            Name = role.Name,
            Weight = role.Weight,
            Perms = role.Perms
        };
    }
}