using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity.Stores;

public class ApplicationRoleStore(LunaLootTenantDbContext context, IdentityErrorDescriber? describer = null)
    : RoleStore<ApplicationRole, LunaLootTenantDbContext, Guid>(context, describer);