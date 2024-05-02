using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Identity;

public class IdentityRole: AggregateRoot<IdentityRoleId, Guid>
{

    [StringLength(32)]
    public string Name { get; private init; } = string.Empty;

    [StringLength(128)]
    public string? Description { get; private init; }

    public UInt16 Weight { get; private init; }
    
    public Permissions Permissions { get; init; } 
    
    [JsonIgnore]
    public ICollection<IdentityUser> Users { get; } = new List<IdentityUser>();
    
    
    private IdentityRole() {}

    private IdentityRole(
        IdentityRoleId id, string name, string? description,
        UInt16 weight,
        List<IdentityUser> users,
        Permissions? permissions) : base(id)
    {

        Description = description;
        Name = !string.IsNullOrWhiteSpace(name) ? 
            name : 
            throw new InvalidOperationException("Role name can not be null or whitespace");

        Weight = weight;
        Permissions = permissions ?? Permissions.None;
        Users = users ?? new List<IdentityUser>();
    }


    public static IdentityRole CreateNew(
        string name,
        string? description,
        UInt16 weight,
        Permissions? permissions,
        List<IdentityUser> users) => 
            new(
                id:IdentityRoleId.CreateNew(), 
                name: name, 
                description: description, 
                weight: weight,
                users: users, 
                permissions: permissions
            );
    
    public static IdentityRole Parse(
        IdentityRoleId id,
        string name,
        string? description,
        UInt16 weight,
        Permissions? permissions,
        List<IdentityUser> users
        )  => 
        new(
            id: id, 
            name: name, 
            description: description, 
            weight: weight,
            users: users, 
            permissions: permissions
        );
}