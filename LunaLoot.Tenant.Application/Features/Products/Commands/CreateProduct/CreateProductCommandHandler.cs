using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using LunaLoot.Tenant.Application.Common.Persistence;
using LunaLoot.Tenant.Domain.Aggregates.Products;
using LunaLoot.Tenant.Domain.Aggregates.Products.Entities;
using LunaLoot.Tenant.Domain.Aggregates.Products.Enums;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IUnitOfWork unitOfWork
    ): IRequestHandler<
    CreateProductCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var price = Price.Create(
            request.Price?.Currency ?? Currency.TL,
            request.Price?.Amount ?? 0);
        
        var product = Product.Create(
            ProductId.Create(),
            request.Name,
            request.Description,
            price,
            BrandId.Create(request.BrandId),
            null,
            request.Specifications,
            request.Variants.ConvertAll<ProductVariant>(ProductVariant.Create)
        );

        return await unitOfWork.ProductRepository.AddAsync(product, cancellationToken);
    }
}