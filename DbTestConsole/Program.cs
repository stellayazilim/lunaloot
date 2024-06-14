// See https://aka.ms/new-console-template for more information

using LunaLoot.Tenant.Domain.Aggregates.Product;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
var options = new DbContextOptionsBuilder<LunaLootTenantDbContext>();
options.UseNpgsql(
    "" +
    "Server=127.0.0.1;" +
    "Port=5432;" +
    "Database=LunaLootTenant;" +
    "User Id=postgres;" +
    "Password=postgres;");

var dbContext = new LunaLootTenantDbContext(
    options.Options
);

//
// var product1_id = ProductId.Create();
// var product2_id = ProductId.Create();
// var brand1_id = BrandId.Create();
//
//
// var brand1 = Brand.Create(
//     brand1_id,
//     "brand_1",
//     "brand_1 aciklama",
//     null);
//
// var product1 = Product.Create(
//         product1_id,
//         "Urun 1",
//         "Urun 1 aciklama",
//         Price.Create(Currency.TL, 10212.12m),
//         brand1_id,
//         brand1,
//         null,
//         null
//         
//     );
var old_p = dbContext.Set<Product>()
    .Include(x => x.Variants).First(
        x => x.Id == ProductId.Create(Guid.Parse("cb8916f3-4e4b-4ec9-8766-a6e01822a72d")));

// var variant = ProductVariant.Create(
//     ProductVariantId.Create(),   
//     "test",
//     old_p.Id,
//     old_p,
//     "test variant description"
//
// );
// product1.AddVariant(variant);
//
// dbContext.Set<Brand>().Add(brand1);
// dbContext.Set<Product>().Add(product1);
// dbContext.SaveChanges();
int t = int.Parse(Console.ReadLine());

Console.WriteLine(t);
Console.WriteLine(old_p.Variants.First().Description);