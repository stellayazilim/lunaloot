using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;
using LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;
using LunaLoot.Master.Contracts.Features.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;


[Route("role")]
public class RoleController
    (ISender mediatr): ApiController
{

    [HttpPost("")]
    public async Task<IActionResult> CreateRole(
        [FromBody] CreateRoleRequest request, 
        CancellationToken cancellationToken)
    {
         return await mediatr.Send((CreateRoleCommand)request, cancellationToken).Match(
            CreateRoleResponse.ToActionResult,
            Problem
         );
    }


    [HttpGet("")]
    public async Task<IActionResult> ListRole(CancellationToken cancellationToken)
    {
        return await mediatr.Send(new ListRolesQuery(), cancellationToken).Match(
            ListRoleResponse.ToActionResult,
            Problem
        );
    }
}