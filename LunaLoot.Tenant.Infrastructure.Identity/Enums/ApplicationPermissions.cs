namespace LunaLoot.Tenant.Domain.Identity.Enums;

[Flags]
public enum ApplicationPermissions
{
    None = 0,
    ReadUsers = 1,
    UpdateUsers = ReadUsers * 2,
    ReadRoles =  UpdateUsers * 2,
    UpdateRoles = ReadRoles * 2,
    All = ~None
}