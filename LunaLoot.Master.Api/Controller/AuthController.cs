using System.Security.Claims;
using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Auth.Commands.Register;
using LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;
using LunaLoot.Master.Contracts.Auth.Login;
using LunaLoot.Master.Contracts.Auth.Register;
using LunaLoot.Master.Contracts.Common.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;


[Route("auth")]
public class AuthController(
    ISender mediator) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        return await mediator.Send((RegisterCommand)request).Match(
                Ok,
                Problem
            );
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> LoginWithCredentials(LoginRequest request)
    {
        return await mediator.Send((LoginWithPasswordQuery)request).Match(
            LoginResponse,
            Problem
        );
    }

    [HttpGet("")]
    [Authorize]
    [RequirePerms(new string[]
    {
        "role.read.role"
    })]
    public IActionResult TestAuth()
    {
        

        return Ok();
    }

    private OkObjectResult LoginResponse(LoginWithPasswordQueryResult result)
    {
        var response = new LoginResponse();
        response = result;
        return Ok(response);
    }
}