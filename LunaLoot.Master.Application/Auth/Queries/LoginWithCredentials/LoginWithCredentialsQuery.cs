using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

public record LoginWithCredentialsQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<LoginWithPasswordQueryResult>>;

