using System.ComponentModel.DataAnnotations;
using LunaLoot.Master.Domain.Address.ValueObjects;
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace LunaLoot.Master.Domain.Auth;

public class ApplicationUser: AggregateRoot<ApplicationUserId> 
{
    private ApplicationUser(
        ApplicationUserId id,
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string password,
        string? verificationCode,
        List<AddressId> addresses,
        List<ApplicationRole> applicationRoles) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        VerificationCode = verificationCode;
        _addresses = addresses;
        _roles = applicationRoles;
    }
    
    #pragma warning disable CS8618 
    private ApplicationUser() {}
    #pragma warning restore CS8618 
    
    [StringLength(maximumLength:64)]
    public string FirstName { get; private set; }
    
    [StringLength(maximumLength:64)]
    public string LastName { get; private set; }
    
    [StringLength(maximumLength:64)]
    public string Email { get; private set; }
    
    [StringLength(maximumLength:11)]
    public string PhoneNumber { get; private set; }
    
    [StringLength(256)]
    public string Password { get; private set; }

    public string? VerificationCode { get; private set; } 
    
    public bool IsEmailVerified { get; private set; }
    
    public bool IsPhoneVerified { get; private set; }
    
    public byte LoginAttempts { get; private set; }

    public DateTime LastLoginAttempt;
    
    private List<ApplicationRole> _roles = new();

    private List<AddressId> _addresses = new();
    public IReadOnlyList<AddressId> Addresses => _addresses.AsReadOnly(); 
    public IReadOnlyList<ApplicationRole> Roles => _roles.AsReadOnly();

    public static ApplicationUser CreateNew(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string password,
            string? verificationCode,
            List<AddressId> addresses,
            List<ApplicationRole> roles)
        => new(
                ApplicationUserId.CreateNew(), 
                firstName,
                lastName,
                email,
                phoneNumber,
                password,
                verificationCode,
                addresses,
                roles
            );

  
}