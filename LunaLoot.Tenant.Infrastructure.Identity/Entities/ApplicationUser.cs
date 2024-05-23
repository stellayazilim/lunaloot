using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Tenant.Domain.Identity.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class ApplicationUser: IdentityUser<Guid>
{
    public static ApplicationUser CreateNew(
        Guid id,
        string email,
        string password) => new()
    {
        Id = id,
        Email = email,
        UserName = email,
        NormalizedEmail = email,
        PasswordHash = password
    };
}