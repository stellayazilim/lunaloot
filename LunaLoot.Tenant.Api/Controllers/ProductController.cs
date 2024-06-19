using ErrorOr;
using LunaLoot.Tenant.Api.Common;
using LunaLoot.Tenant.Api.Contracts.Common;
using LunaLoot.Tenant.Api.Contracts.Product;
using LunaLoot.Tenant.Application.Common.Models;
using LunaLoot.Tenant.Application.Features.Products.Commands.CreateProduct;
using LunaLoot.Tenant.Application.Features.Products.Queries.ListProduct;
using LunaLoot.Tenant.Domain.Aggregates.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Tenant.Api.Controllers;

[Route("product")]
public class ProductController(ISender mediatr): ApiController
{

    [HttpPost("")]
    public async Task<IActionResult> CreateProducts(
        CreateProductRequest request, 
        CancellationToken cancellationToken)
    {
        return await mediatr.Send(
            (CreateProductCommand)request, 
            cancellationToken).Match(
                EmptyResponse.ToActionResult,
                Problem
            );
    }

    
    [HttpGet("")]
    public async Task<IActionResult> ListProducts(
        [FromQuery] PaginatedRequest<Product> request,
        CancellationToken cancellationToken )
    {
        // return await mediatr.Send(
        //     new ListProductQuery(
        //         request.Size,
        //         request.Page
        //         ),
        //     cancellationToken )
        //     .Match( Ok, Problem);

        return Ok();
    }
}