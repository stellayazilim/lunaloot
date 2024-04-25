using LunaLoot.Master.Domain.Common.Enums;

namespace LunaLoot.Master.Infrastructure.Auth;

public class PolicyNameHelper
{
    public const string Prefix = "Permissions";

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
        var permissionsValue = int.Parse(policyName[Prefix.Length..]!);

        return (Permissions)permissionsValue;
    }
}