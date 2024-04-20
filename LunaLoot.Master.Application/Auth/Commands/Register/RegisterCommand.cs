﻿using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password): IRequest<ErrorOr<RegisterCommandResult>>;