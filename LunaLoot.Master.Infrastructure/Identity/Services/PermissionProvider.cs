using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity.Enums;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class PermissionProvider: IPermissionProvider
{
    public List<KeyValuePair<string, int>> GetPermissions()
    {
        var enumValues = Enum.GetValues(typeof(Permissions)).Cast<Permissions>();
        return enumValues.Where( x => x != Permissions.All && x != Permissions.None).ToList().ConvertAll(x => new KeyValuePair<string, int>(Enum.GetName(x)!, (int)x));
    }
}