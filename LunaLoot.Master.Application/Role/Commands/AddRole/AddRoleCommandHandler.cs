using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using MediatR;

namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public class AddRoleCommandHandler(
    IUnitOfWork unitOfWork
    ):IRequestHandler<AddRoleCommand, ErrorOr<AddRoleCommandResult>>
{
    public Task<ErrorOr<AddRoleCommandResult>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}