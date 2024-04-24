using System.ComponentModel.DataAnnotations;
using LunaLoot.Master.Domain.Address.ValueObjects;
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.Events;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace LunaLoot.Master.Domain.Auth;

/// <summary>
/// The application user class
/// </summary>
/// <seealso cref="AggregateRoot{ApplicationUserId}"/>
public class ApplicationUser: AggregateRoot<ApplicationUserId, Guid> 
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class
    /// </summary>
    /// <param name="id">The id</param>
    /// <param name="firstName">The first name</param>
    /// <param name="lastName">The last name</param>
    /// <param name="email">The email</param>
    /// <param name="phoneNumber">The phone number</param>
    /// <param name="password">The password</param>
    /// <param name="verificationCode">The verification code</param>
    /// <param name="addresses">The addresses</param>
    /// <param name="applicationRoles">The application roles</param>
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
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class
    /// </summary>
    private ApplicationUser() {}
    #pragma warning restore CS8618 
    
    /// <summary>
    /// Gets or sets the value of the first name
    /// </summary>
    [StringLength(maximumLength:64)]
    public string FirstName { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the last name
    /// </summary>
    [StringLength(maximumLength:64)]
    public string LastName { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the email
    /// </summary>
    [StringLength(maximumLength:64)]
    public string Email { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the phone number
    /// </summary>
    [StringLength(maximumLength:11)]
    public string PhoneNumber { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the password
    /// </summary>
    [StringLength(256)]
    public string Password { get; private set; }

    /// <summary>
    /// Gets or sets the value of the verification code
    /// </summary>
    public string? VerificationCode { get; private set; } 
    
    /// <summary>
    /// Gets or sets the value of the is email verified
    /// </summary>
    public bool IsEmailVerified { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the is phone verified
    /// </summary>
    public bool IsPhoneVerified { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the login attempts
    /// </summary>
    public byte LoginAttempts { get; private set; }

    /// <summary>
    /// The last login attempt
    /// </summary>
    public DateTime LastLoginAttempt;
    
    /// <summary>
    /// The roles
    /// </summary>
    private List<ApplicationRole> _roles = new();

    /// <summary>
    /// The addresses
    /// </summary>
    private List<AddressId> _addresses = new();
    /// <summary>
    /// Gets the value of the addresses
    /// </summary>
    public IReadOnlyList<AddressId> Addresses => _addresses.AsReadOnly(); 
    /// <summary>
    /// Gets the value of the roles
    /// </summary>
    public IReadOnlyList<ApplicationRole> Roles => _roles.AsReadOnly();

    /// <summary>
    /// Creates the new user
    /// </summary>
    /// <param name="firstName">The first name</param>
    /// <param name="lastName">The last name</param>
    /// <param name="email">The email</param>
    /// <param name="phoneNumber">The phone number</param>
    /// <param name="password">The password</param>
    /// <param name="verificationCode">The verification code</param>
    /// <param name="addresses">The addresses</param>
    /// <param name="roles">The roles</param>
    /// <returns>The application user</returns>
    public static ApplicationUser CreateNew(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string password,
        string? verificationCode,
        List<AddressId> addresses,
        List<ApplicationRole> roles)
    {
        var user = new ApplicationUser(
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

        user.AddDomainEvent(new UserCreated(user));

        return user;
    }

  
}