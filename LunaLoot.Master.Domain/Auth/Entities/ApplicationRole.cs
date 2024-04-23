
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.Entities;

public class ApplicationRole: Entity<ApplicationRoleId>
{
    public string Name { get; set; }

    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private  List<string> _perms;
    public IReadOnlyList<string> Perms => _perms.AsReadOnly();

    private List<ApplicationUser> _users = new();
    public IReadOnlyList<ApplicationUser> Users => _users.AsReadOnly();
    
    
    private ApplicationRole(
        ApplicationRoleId id,
        string name,
        List<ApplicationUser> users,
        List<string> perms): base(id)
    {
        Name = name;
        _perms = perms;
        _users = users;
    }
    
    private ApplicationRole() {}

    public static ApplicationRole CreateNew(
        string name,
        List<ApplicationUser> users,
        List<string> perms) => new(
            ApplicationRoleId
                .CreateNew(),
            name,
            users,
            perms);


}