using LunaLoot.Tenant.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Tenant.Domain.Identity.Entities;

public sealed class ApplicationRole: IdentityRole<Guid>
{
    // ReSharper disable once CollectionNeverUpdated.Local
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    // ReSharper disable once MemberInitializerValueIgnored
    // ReSharper disable once HeapView.ObjectAllocation
    private List<ApplicationPermissions> _permissions  = [];

    public static ApplicationRole CreateNew(
        Guid id,
        string name,
        List<ApplicationPermissions>? perms) => new()
    {
        Id = id,
        Name = name,
        _permissions = perms ?? new()
    };

    public IReadOnlyList<ApplicationPermissions> Permissions => _permissions.AsReadOnly();
}