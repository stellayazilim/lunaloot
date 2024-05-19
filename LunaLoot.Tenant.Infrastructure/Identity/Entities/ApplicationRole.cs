using LunaLoot.Tenant.Infrastructure.Identity.Enums;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Tenant.Infrastructure.Identity.Entities;

public class ApplicationRole: IdentityRole<Guid>
{
    // ReSharper disable once CollectionNeverUpdated.Local
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    // ReSharper disable once MemberInitializerValueIgnored
    // ReSharper disable once HeapView.ObjectAllocation
    private List<ApplicationPermissions> _permissions  = [];

    public ApplicationRole()
    {
        _permissions = new();
    }

    public IReadOnlyList<ApplicationPermissions> Permissions => _permissions.AsReadOnly();
}