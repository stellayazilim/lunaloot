﻿using ErrorOr;
using LunaLoot.Master.Api.Common;
using LunaLoot.Master.Application.Features.Identity.Commands.RegisterUser;
using LunaLoot.Master.Application.Features.Identity.Queries.Login;
using LunaLoot.Master.Contracts.Common.Attributes;
using LunaLoot.Master.Contracts.Common.General;
using LunaLoot.Master.Contracts.Features.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;

[Route("auth")]
public class AuthController(
    ILogger<AuthController> logger,
    ISender mediatr
    ): ApiController
{
    private readonly ILogger<AuthController> _logger = logger;
    
    [AnonymousOnly]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request,  CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Request receive: { DateTime.UtcNow }");
        if (!ModelState.IsValid) return Problem();
        _logger.LogInformation($"Model validate: { DateTime.UtcNow}");
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
    [Authorize(Permissions.ReadUser)]
    [Authorize(Permissions.EditUser)]
    [Authorize(Permissions.EditRole)]
    public async void Protected()
    {
        
    }
}