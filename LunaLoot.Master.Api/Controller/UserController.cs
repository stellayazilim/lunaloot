using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Features.Identity.Queries.ListUsers;
using LunaLoot.Master.Contracts.Common.Attributes;
using LunaLoot.Master.Contracts.Common.Identity;
using LunaLoot.Master.Contracts.Features.Users;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;

[Route("user")]
public class UserController(
    ISender mediatr): ApiController
{

    
    [HttpGet("")]
    [Authorize(Permissions.ReadUser)]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        return await mediatr.Send(new ListUsersQuery(), cancellationToken).Match(
            ListUsersResponse.ToActionResult,
            Problem
        );
    }
}