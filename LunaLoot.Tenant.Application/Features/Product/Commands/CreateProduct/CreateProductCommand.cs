using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Product.Commands.CreateProduct;

public record CreateProductCommand(): IRequest<ErrorOr<EmptyResult>>;