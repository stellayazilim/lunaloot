using LunaLoot.Tenant.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity.Stores;

public class ApplicationRoleStore(LunaLootTenantIdentityDbContext context, IdentityErrorDescriber? describer = null)
    : RoleStore<ApplicationRole, LunaLootTenantIdentityDbContext, Guid>(context, describer);