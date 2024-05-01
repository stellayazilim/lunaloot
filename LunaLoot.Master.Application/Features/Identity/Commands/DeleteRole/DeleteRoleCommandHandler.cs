using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.DeleteRole;

public class DeleteRoleCommandHandler: IRequestHandler<DeleteRoleCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new EmptyResult();
    }
}