using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public class AddRoleCommandHandler(
    IUnitOfWork unitOfWork
    ):IRequestHandler<AddRoleCommand, ErrorOr<AddRoleCommandResult>>
{
    public async Task<ErrorOr<AddRoleCommandResult>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        // @todo add ErrorOr pattern for services & repositories
        await Task.CompletedTask;

        var role = IdentityRole.CreateNew(
                request.Name,
                null,
                request.Weight,
                request.Perms,
                new ()
            
            );


        return new AddRoleCommandResult();
    }
}