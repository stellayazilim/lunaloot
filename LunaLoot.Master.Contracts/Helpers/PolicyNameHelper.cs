using System.Diagnostics;
using LunaLoot.Master.Domain.Identity.Enums;

namespace LunaLoot.Master.Contracts.Helpers;

public static class PolicyNameHelper
{
    public const string Prefix = "permissions";

    public static bool IsValidPolicyName(string? policyName)
    {
        return policyName != null && policyName.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase);
    }

    public static string GeneratePolicyNameFor(Permissions permissions)
    {
        return $"{Prefix}{(int)permissions}";
    }

    public static Permissions GetPermissionsFrom(string policyName)
    {
        // ReSharper disable once NullableWarningSuppressionIsUsed
        var permissionsValue = int.Parse(policyName[Prefix.Length..]!);
            
        Debug.WriteLine(permissionsValue);
        return (Permissions)permissionsValue;
    }
}