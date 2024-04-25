using LunaLoot.Master.Domain.Common.Enums;

namespace LunaLoot.Master.Infrastructure.Auth;

public class PermissionsProvider
{
    public static List<Permissions> GetAll()
    {
        return Enum.GetValues(typeof(Permissions))
            .OfType<Permissions>()
            .ToList();
    }
}