using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.Entities;

public class ApplicationClaim: Entity<ApplicationClaimId>
{
    public ApplicationClaim(ApplicationClaimId id) : base(id)
    {
    }
    
    public string Key { get; set; }
    public string Value { get; set; }
}