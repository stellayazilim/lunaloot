
using LunaLoot.Tenant.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity.Stores;

public class ApplicationUserStore(LunaLootTenantIdentityDbContext context, IdentityErrorDescriber? describer = null)
    : UserStore<ApplicationUser, ApplicationRole, LunaLootTenantIdentityDbContext, Guid>(context, describer);
