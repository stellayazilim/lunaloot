using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Auth.Commands.Register;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Address.ValueObjects;

// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Contracts.Auth.Register;

public record RegisterRequest()
{
    
    
    [JsonPropertyName("address")]
    public AddressDto Address { get; set; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; init; } = null!;
    
    
    [JsonPropertyName("lastName")]
    public string LastName { get; init; } = null!;
    
    [JsonPropertyName("phoneNumber")]
    [StringLength(11, MinimumLength = 11)]
    [Phone]
    public string PhoneNumber { get; set; }
    
    [JsonPropertyName("email")] 
    [EmailAddress]
    [StringLength(64)]
    public string Email { get;  init; } = null!;  
    
    
    [JsonPropertyName("password")] 
    public string Password { get; init; } = null!;  


    public static implicit operator RegisterCommand(RegisterRequest request)
    {
        return new RegisterCommand(
            FirstName: request.FirstName,
            LastName: request.LastName,
            Email: request.Email,
            PhoneNumber:request.PhoneNumber,
            Address: request.Address,
            Password: request.Password);

    }
};




public record AddressDto
{

    [JsonPropertyName("country")] 
    public string Country { get; set; } = string.Empty;
    
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;
    
    [JsonPropertyName("province")]
    public string Province { get; set; } = string.Empty;
    
    [JsonPropertyName("town")]
    public string Town { get; set; } = string.Empty;
    
    [JsonPropertyName("street")]
    public string Street { get; set; } = string.Empty;
    
    [JsonPropertyName("postCode")]
    public string PostCode { get; set; } = string.Empty;
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    public static implicit operator AddressDto(RegisterCommandAddress address)
    {
        return new AddressDto()
        {
            Country = address.Country,
            City = address.City,
            Province = address.Province,
            Town = address.Town,
            Street = address.Street,
            PostCode = address.PostCode,
            Name = address.Name,
            Description = address.Description
        };
    }

    public static implicit operator RegisterCommandAddress(AddressDto address)
    {
        return new RegisterCommandAddress(
                Country: address.Country,
                City: address.City,
                Province: address.Province,
                Town: address.Town,
                Street: address.Street,
                PostCode: address.PostCode,
                Name: address.Name,
                Description: address.Description
            );
    }
}


