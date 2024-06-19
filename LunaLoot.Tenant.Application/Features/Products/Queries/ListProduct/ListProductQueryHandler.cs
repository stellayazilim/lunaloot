using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;
using LunaLoot.Tenant.Application.Common.Persistence;
using LunaLoot.Tenant.Application.Features.Products.Models;
using LunaLoot.Tenant.Domain.Aggregates.Products;
using MediatR;

namespace LunaLoot.Tenant.Application.Features.Products.Queries.ListProduct;

public class ListProductQueryHandler
    (IUnitOfWork unitOfWork): IRequestHandler<
    ListProductQuery, ErrorOr<PaginatedResult<Product>>>

{
    public async Task<ErrorOr<PaginatedResult<Product>>> Handle(
        ListProductQuery request, 
        CancellationToken cancellationToken)
    {

        var skip = (request.Page - 1) * request.Size;
        var take = request.Size;
        return await unitOfWork.ProductRepository.GetAllAsync(skip, take);
        
       
    }
}