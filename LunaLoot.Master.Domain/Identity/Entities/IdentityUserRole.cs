using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Identity.Entities;

public class IdentityUserRole: Entity<IdentityUserRoleId>
{

    public IdentityUserRole() { }
    
    public IdentityUserRole(IdentityUserRoleId id ): base(id) { }
    
    public IdentityUserId IdentityUserId { get; set; }
    
    public IdentityRoleId IdentityRoleId { get; set; }
 }