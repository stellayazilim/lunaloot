using LunaLoot.Master.Domain.Identity.Enums;

namespace LunaLoot.Master.Contracts.Common.Identity;

﻿using Microsoft.AspNetCore.Authorization;


public class PermissionAuthorizationRequirement : IAuthorizationRequirement
{
    public PermissionAuthorizationRequirement(Permissions permission)
    {
        Permissions = permission;
    }

    public Permissions Permissions { get; }
}