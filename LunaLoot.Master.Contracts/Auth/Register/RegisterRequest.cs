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

    
    
    
    // public static implicit operator RegisterRequest(RegisterCommand command)
    // {
    //     return new RegisterRequest()
    //     {
    //       FirstName = command.FirstName,
    //       LastName = command.LastName,
    //       PhoneNumber = command.PhoneNumber,
    //       Email = command.Email,
    //       Address = command.Address,
    //       Password = command.Password
    //     };
    // }

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
    public CountryDto Country { get; set; }
    
    [JsonPropertyName("city")]
    public string City { get; set; }
    
    [JsonPropertyName("province")]
    public string Province { get; set; }
    
    [JsonPropertyName("town")]
    public string Town { get; set; }
    
    [JsonPropertyName("street")]
    public string Street { get; set; }
    
    [JsonPropertyName("postCode")]
    public string PostCode { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
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


public record CountryDto
{ 
    [JsonPropertyName("asciiCode")]
    public string? AsciiCode { get; set; }
    
    [JsonPropertyName("isoCode")]
    public string? IsoCode { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    public static implicit operator CountryDto(RegisterCommandCountry country)
    {
        return new CountryDto()
        {
            AsciiCode = country?.AsciiCode,
            IsoCode = country?.IsoCode,
            #pragma warning disable CS8602 
            Name = country.Name,
        };
    }

    public static implicit operator RegisterCommandCountry(CountryDto dto)
    {
        return new RegisterCommandCountry(
            IsoCode: dto?.IsoCode,
            AsciiCode: dto?.AsciiCode,
            Name: dto.Name);
    }
    
}