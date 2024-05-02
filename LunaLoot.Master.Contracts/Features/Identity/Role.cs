using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Features.Identity.Commands.AddRoleToUser;
using LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;
using LunaLoot.Master.Application.Features.Identity.Commands.EditRole;
using LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = LunaLoot.Master.Application.Common.Models.EmptyResult;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Contracts.Features.Identity;


#region CreateRole
    public record CreateRoleRequest
    {
        [JsonPropertyName("name")] 
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")] 
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("weight")]
        public ushort Weight { get; set; }

        [JsonPropertyName("permissions")] 
        public Permissions[] Permissions { get; init; } = new Permissions[]{};

        public static explicit operator CreateRoleCommand(CreateRoleRequest request)
        {
            Permissions permissions = Domain.Identity.Enums.Permissions.None;
            
            request.Permissions.ToList().ForEach(x =>
            {
                permissions |= x;
            });
            return new CreateRoleCommand(
                Name: request.Name,
                Description: request.Description,
                Weight: request.Weight,
                Permissions: permissions
            );
        }
    }

    public record CreateRoleResponse
    {
        public static IActionResult ToActionResult(EmptyResult result)
        {
            return new OkObjectResult(new CreateRoleResponse());
        }
    }
#endregion



#region List Roles

    public record ListRoleResponse
    {
        public List<ListRoleItem> Data { get; set; } = new();

        public bool? HasNextPage { get; set; }

        public bool? HasPreviousPage { get; set; }

        public string? NextPage { get; set; } 
        
        public string? PreviousPage { get; set; }

        public static IActionResult ToActionResult(ListRolesQueryResult result)
        {
            return new OkObjectResult(new ListRoleResponse()
            {
                Data = result.Roles.ConvertAll<ListRoleItem>(x => x)
            });
        }
    }

    public record ListRoleItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")] 
        public string? Description { get; set; } = string.Empty;
        
        [JsonPropertyName("weight")]
        public ushort Weight { get; set; }

        [JsonPropertyName("permissions")] 
        public Permissions Permissions { get; set; }

        public static implicit operator ListRoleItem(IdentityRole role)
        {
            return new ListRoleItem()
            {
                Id = role.Id.Value,
                Name = role.Name,
                Description = role.Description,
                Weight = role.Weight,
                Permissions = role.Permissions,
            };
        }
    }

#endregion


#region AddRoleToUser
    public record AddRoleToUserRequest
    {
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
        
        [JsonPropertyName("roleId")]
        public Guid RoleId { get; set; }

        public static explicit operator AddRoleToUserCommand(AddRoleToUserRequest request)
        {
            return new AddRoleToUserCommand(
                    IdentityUserId.Parse(request.UserId),
                    IdentityRoleId.Parse(request.RoleId)
                );
        }
    }
#endregion

#region EditRole
    public record EditRoleRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")] 
        public string? Description { get; set; } = string.Empty;
        
        [JsonPropertyName("weight")]
        public ushort Weight { get; set; }

        [JsonPropertyName("permissions")] 
        public Permissions Permissions { get; set; }

        public static explicit operator EditRoleCommand(EditRoleRequest request)
        {
            return new EditRoleCommand(
                IdentityRoleId.Parse(request.Id),
                request.Name,
                request.Description,
                request.Weight,
                request.Permissions
                );
        }
    }

#endregion