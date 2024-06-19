using LunaLoot.Tenant.Api.Contracts.Common;
using LunaLoot.Tenant.Application.Features.Products.Commands.CreateProduct;
using _price = LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects.Price;

namespace LunaLoot.Tenant.Api.Contracts.Product;

public record CreateProductRequest
{

    public CreateProductRequest(
        string name,
        string description,
        Guid brandId,
        Guid categoryId, 
        PriceRequest price,
        List<KeyValuePair<string, string>> specifications,
        List<Guid> variants)
    {
        Name = name;
        Description = description;
        BrandId = brandId;
        CategoryId = categoryId;
        Price = price;
        Specifications = specifications;
        Variants = variants;
    }
    public string Name { get; init; } 
    public string Description { get; init;}  
    public Guid BrandId { get; init; } 
    public Guid CategoryId { get; init; } 
    public PriceRequest Price { get; init; }
    public List<KeyValuePair<string, string>> Specifications { get; set; }
    public List<Guid> Variants { get; init; }

    public static explicit operator CreateProductCommand(CreateProductRequest request)
    {
        return new CreateProductCommand(
            Name: request.Name,
            Description: request.Description,
            Price: _price.Create(
                request.Price.Currency,
                request.Price.Amount
                ),
            BrandId: request.BrandId,
            Specifications: request.Specifications,
            Variants: request.Variants
            );
    }
}