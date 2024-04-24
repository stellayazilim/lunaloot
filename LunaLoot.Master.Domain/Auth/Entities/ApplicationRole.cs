
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.Entities;

public class ApplicationRole: Entity<ApplicationRoleId>
{
    public string Name { get; set; }
    public byte Weight { get; init; }
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private  List<string> _perms;
    public IReadOnlyList<string> Perms => _perms.AsReadOnly();
  
    
    private ApplicationRole(
        ApplicationRoleId id,
        string name,
        byte weight,
        List<string> perms): base(id)
    {
        Name = name;
        Weight = weight;
        _perms = perms;
    }
    
    private ApplicationRole() {}

    public static ApplicationRole CreateNew(
        string name,
        byte weight,
        List<string> perms) => new(
            ApplicationRoleId
                .CreateNew(),
            name,
            weight,
            perms);

    public static ApplicationRole Parse(
        ApplicationRoleId id,
        string name,
        byte weight,
        List<string> perms) => 
        new(
            id,
            name,
            weight,
            perms);

}