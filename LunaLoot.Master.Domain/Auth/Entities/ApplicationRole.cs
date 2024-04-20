using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.Entities;

public class ApplicationRole: Entity<ApplicationRoleId>
{
    public ApplicationRole(ApplicationRoleId id) : base(id)
    {
    }
    
    public string Name { get; set; }
    private List<ApplicationClaimId> _claims = new();
    public IReadOnlyList<ApplicationClaimId> Claims => _claims.AsReadOnly();
}