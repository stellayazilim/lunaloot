using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using LunaLoot.Tenant.Application.Features.Products.Models;
using LunaLoot.Tenant.Domain.Aggregates.Products;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Products.Queries.ListProduct;

public record ListProductQuery(int Size, int Page): 
    PaginatedRequest<Product>(Size, Page), 
    IRequest<ErrorOr<PaginatedResult<ProductResult>>>;
