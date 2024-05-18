namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

public interface IPermissionProvider
{
    List<KeyValuePair<string, int>> GetPermissions();
}