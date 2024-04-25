using LunaLoot.Master.Domain.Common.Enums;
using LunaLoot.Master.Infrastructure.Auth;

namespace LunaLoot.Master.Contracts.Common.Attributes;

public class AuthorizeAttribute: Microsoft.AspNetCore.Authorization.AuthorizeAttribute
{
    
    public AuthorizeAttribute() {}
    public AuthorizeAttribute(string policy): base(policy) {}

    public AuthorizeAttribute(Permissions permissions)
    {
        Permissions = permissions;
    }

    public Permissions Permissions
    {
        get
        {
            return !string.IsNullOrEmpty(Policy)
                ? PolicyNameHelper.GetPermissionsFrom(Policy)
                : Permissions.None;
        }
        set
        {
            Policy = value != Permissions.None
                ? PolicyNameHelper.GeneratePolicyNameFor(value)
                : string.Empty;
        }
    }
}