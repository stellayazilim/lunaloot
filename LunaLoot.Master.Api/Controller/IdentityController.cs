using System.Security.Claims;
using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Features.Identity.Commands.RegisterUser;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Application.Features.Identity.Queries.ListPerms;
using LunaLoot.Master.Application.Features.Identity.Queries.Login;
using LunaLoot.Master.Contracts.Common.Attributes;
using LunaLoot.Master.Contracts.Common.General;
using LunaLoot.Master.Contracts.Common.Identity;
using LunaLoot.Master.Contracts.Features.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LunaLoot.Master.Api.Controller;

[Route("identity")]
public class IdentityController(
    ILogger<IdentityController> logger,
    ISender mediatr,
    IPermissionProvider permissionProvider
    ): ApiController
{
    private readonly ILogger<IdentityController> _logger = logger;
    
    [AnonymousOnly]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request,  CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return Problem();
        return await mediatr.Send((LoginQuery)request, cancellationToken)
            .Match(
                new LoginResponse().ToActionResult,
                Problem 
            );
    }

    [AnonymousOnly]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {

        if (!ModelState.IsValid) return Problem();
        return await mediatr.Send((RegisterUserCommand)request, cancellationToken)
            .Match(
                 EmptyResponse.ToActionResult,
                 Problem
            );

    }

    [HttpGet("")]
    [Authorize(Permissions.None)]
    public async void Protected()
    {
        
    }

    [HttpGet("permissions")]
    public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken)
    {
        return await mediatr.Send(new ListPermsQuery(), cancellationToken)
            .Match(
                Ok,
                Problem
            );
    }

    [HttpGet("whoiam")]
    [Authorize]
    public IActionResult Whoiam()
    {

        var roleClaim = HttpContext.User.FindAll(
            c => c.Type == CustomClaimTypes.Roles);
        var roles = roleClaim.Select( x => 
            JsonConvert.
                DeserializeObject<ListRoleItem>(x.Value)).ToList();
        var response = new WhoiamResponse()
        {
            Email = HttpContext.User.Identity?.Name,
            Id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
            IsAuthenticated = HttpContext.User.Identity?.IsAuthenticated,
            Roles = roles
        };
        return Ok(response);
    }
}