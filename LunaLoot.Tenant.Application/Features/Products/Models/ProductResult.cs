﻿using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

namespace LunaLoot.Tenant.Application.Features.Products.Models;

public record ProductResult
{
    public ProductResult(
        Guid Id,
        string Name,
        string Description,
        Price Price,
        Guid BrandId,
        List<KeyValuePair<string, string>> Specifications,
        List<Guid> Variants)
    {
        this.Price = Price;
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.BrandId = BrandId;
        this.Specifications = Specifications;
        this.Variants = Variants;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Price Price { get; set; }

    public Guid BrandId { get; set; }
    
    public List<KeyValuePair<string, string>> Specifications { get; set; }

    public List<Guid> Variants { get; set; } = new();

    public static implicit operator ProductResult(Domain.Aggregates.Products.Product product)
    {
        return new ProductResult(
            Id: product.Id.Value,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            BrandId: product.BrandId.Value,
            Specifications: product.Specifications.ToList(),
            Variants: new List<Guid>()
        ); 
    }

   
};