using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    Price? Price,
    Guid BrandId,
    List<KeyValuePair<string,string>> Specifications,
    List<Guid> Variants): IRequest<ErrorOr<EmptyResult>>;