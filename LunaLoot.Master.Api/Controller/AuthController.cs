using System.Security.Claims;
using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Auth.Commands.Register;
using LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;
using LunaLoot.Master.Contracts.Auth.Login;
using LunaLoot.Master.Contracts.Auth.Register;
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
        return await mediator.Send((LoginWithCredentialsQuery)request).Match(
            Ok,
            Problem
        );
    }

    [HttpGet("")]
    [Authorize]
    public IActionResult TestAuth()
    {
        var claims =  HttpContext.User.Identities;

        return Ok(claims.FirstOrDefault().Label);
    }
}