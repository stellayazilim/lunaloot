
using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity.Stores;

public class ApplicationUserStore(LunaLootTenantDbContext context, IdentityErrorDescriber? describer = null)
    : UserStore<ApplicationUser, ApplicationRole, LunaLootTenantDbContext, Guid>(context, describer);
