using System.Text.Json.Serialization;
using LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;
using LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = LunaLoot.Master.Application.Common.Models.EmptyResult;

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