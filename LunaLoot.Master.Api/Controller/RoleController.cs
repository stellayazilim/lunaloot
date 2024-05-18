using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Features.Identity.Commands.AddRoleToUser;
using LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;
using LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;
using LunaLoot.Master.Contracts.Common.Attributes;
using LunaLoot.Master.Contracts.Common.General;
using LunaLoot.Master.Contracts.Common.Identity;
using LunaLoot.Master.Contracts.Features.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = LunaLoot.Master.Application.Common.Models.EmptyResult;

namespace LunaLoot.Master.Api.Controller;


[Route("role")]
public class RoleController
    (ISender mediatr): ApiController
{

    [Authorize(Permissions.EditRole)]
    [HttpPost("")]
    public async Task<IActionResult> CreateRole(
        [FromBody] CreateRoleRequest request, 
        CancellationToken cancellationToken)
    {
         return await mediatr.Send((CreateRoleCommand)request, cancellationToken).Match(
            EmptyResponse.ToActionResult,
            Problem
         );
    }


    [Authorize(Permissions.ReadRole | Permissions.EditRole)]
    [HttpGet("")]
    public async Task<IActionResult> ListRole(CancellationToken cancellationToken)
    {
        return await mediatr.Send(new ListRolesQuery(), cancellationToken).Match(
            ListRoleResponse.ToActionResult,
            Problem
        );
    }


    [Authorize(Permissions.EditRole)]
    [HttpPatch("")]
    public async Task<IActionResult> EditRole()
    {
        return Ok();
    }
    
    
    [Authorize(Permissions.ReadRole | Permissions.EditRole)]
    [Authorize(Permissions.EditUser)]
    [HttpPut("")]
    public async Task<IActionResult> AddUserToRole([FromBody] AddRoleToUserRequest request, CancellationToken cancellationToken)
    {
        return await mediatr.Send((AddRoleToUserCommand)request, cancellationToken).Match(
            EmptyResponse.ToActionResult,
            Problem
        );
    }
}