using LunaLoot.Master.Domain.Common.Enums;
using LunaLoot.Master.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Master.Infrastructure.Identity;

public class ApplicationRole: IdentityRole<string>
{
    public Permissions Permissions { get; set; }
}