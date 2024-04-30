﻿using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.RegisterUser;

public class RegisterUserCommandHandler(
    IIdentityService identityService
    ): IRequestHandler<RegisterUserCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        var user = IdentityUser.CreateNew(
            request.Email,
            request.PhoneNumber,
            PasswordHash.GenerateHashedPassword(request.Password),
            new()
        );

        await identityService.UserManager.CreateUserAsync(user);
        
        return new EmptyResult();
    }
}