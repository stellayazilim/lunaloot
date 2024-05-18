using System.ComponentModel.DataAnnotations;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;


namespace LunaLoot.Master.Domain.Identity;

public sealed class IdentityUser: AggregateRoot<IdentityUserId, Guid>
{
    #region Roles list

        private List<IdentityRole> _roles = new List<IdentityRole>();
        public IReadOnlyCollection<IdentityRole> Roles => _roles.AsReadOnly();
        
        public void AddRole(IdentityRole role)
        {
            _roles.Add(role);
        }
    #endregion

    #region Login list

        private List<IdentityLogin> _logins = new();

        public IReadOnlyCollection<IdentityLogin> Logins => _logins.AsReadOnly();   
        
        public void AddLogin(IdentityLogin login)
        {
            _logins.Add(login);
        }
    #endregion


    
    [StringLength(64)]
    // ReSharper disable once MemberCanBePrivate.Global
    public string Email { get; set; } = String.Empty;
    
    [StringLength(11)]
    public string PhoneNumber { get;  set; } = String.Empty;

    public PasswordHash Password { get; set; }
    
    
    public string NormalizedEmail => Email.ToLower();


    private IdentityUser(
        IdentityUserId id,
        string email,
        string phoneNumber,
        PasswordHash password,
        List<IdentityRole> roles) : base(id)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        _roles = roles;
    }
    
    
    #pragma warning disable CS8618
    public IdentityUser(IdentityUserId id): base(id){}
    public IdentityUser() {}
    #pragma warning restore CS8618

    
    public static IdentityUser Create(
        IdentityUserId id,
        string email,
        string phoneNumber,
        PasswordHash password,
        List<IdentityRole> roles) => new(id, email, phoneNumber, password, roles);

    public static IdentityUser Empty(IdentityUserId id) => new(id);

}
