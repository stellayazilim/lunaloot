using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler: IRequestHandler<
    CreateProductCommand, ErrorOr<EmptyResult>>
{
    public Task<ErrorOr<EmptyResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        
        return Task.FromResult(new EmptyResult().ToErrorOr());
    }
}