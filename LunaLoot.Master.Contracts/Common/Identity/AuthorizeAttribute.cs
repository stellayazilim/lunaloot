﻿using LunaLoot.Master.Domain.Identity.Enums;

namespace LunaLoot.Master.Contracts.Common.Identity;

public class AuthorizeAttribute: Microsoft.AspNetCore.Authorization.AuthorizeAttribute
{
    
    public AuthorizeAttribute() {}
    public AuthorizeAttribute(string policy): base(policy) {}

    public AuthorizeAttribute(Permissions permission)
    {
        Permissions = permission;
    }

    public Permissions Permissions
    {
        get =>
            !string.IsNullOrEmpty(Policy)
                ? PolicyNameHelper.GetPermissionsFrom(Policy)
                : Permissions.None;
        set =>
            Policy = value != Permissions.None
                ? PolicyNameHelper.GeneratePolicyNameFor(value)
                : string.Empty;
    }
}