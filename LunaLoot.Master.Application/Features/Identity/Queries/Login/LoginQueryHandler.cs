using System.Diagnostics;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.Errors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Login;

public sealed class LoginQueryHandler(
    IIdentityManager identityManager,
    IUnitOfWork unitOfWork,
    ILogger<LoginQueryHandler> logger): IRequestHandler<LoginQuery, ErrorOr<LoginQueryResult>>
{
    public async Task<ErrorOr<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        
        logger.LogInformation($"Login Handler : { DateTime.UtcNow }");
        var userResult = await identityManager.GetByEmailAsync(request.Email ?? string.Empty, cancellationToken);
        logger.LogInformation($"Login Handler - Get User By Email: { DateTime.UtcNow}");
        if (userResult.IsError) return userResult.Errors;

        logger.LogInformation($"Login Handler - Verify password: { DateTime.UtcNow}");
        if (!userResult.Value.Password.Verify(request.Password))
            return Errors.Identity.InvalidCredentials;
        logger.LogInformation($"Login Handler - Process Login: { DateTime.UtcNow}");
        var loginResult = await identityManager
            .LoginWithCredentialsAsync(userResult.Value, cancellationToken);

        return loginResult.IsError ? loginResult.Errors : (LoginQueryResult)loginResult.Value;
    }
}