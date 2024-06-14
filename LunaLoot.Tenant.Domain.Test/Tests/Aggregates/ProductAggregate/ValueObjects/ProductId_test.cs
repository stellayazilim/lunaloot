using FluentAssertions;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;

namespace LunaLoot.Tenant.Domain.Test.Tests.Aggregates.ProductAggregate.ValueObjects;

public class ProductIdTest
{

    [Fact]
    public void Test_ProductId_ShouldCreated()
    {
        // arrange
        var id = Guid.NewGuid();
        
        // act
        var productId = ProductId.Create(id);
        
        // assert
        productId.Value.Should().Be(id);
        productId.Should().NotBe(ProductId.Create(Guid.NewGuid()));
    }

    [Fact]
    public void Test_ProductId_ShouldCreatedWithEmptyConstructor()
    {
        // act
        var productId = ProductId.Create();
        
        // assert
        productId.Should().NotBeNull();
    }

    [Fact]
    public void Test_ProductId_GetEqualityComponents_ShouldReturnValueAsSingleComponent()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var productId = ProductId.Create(guid);

        // Act
        var components = productId.GetEqualityComponents().ToList();

        // Assert
        components.Count.Should().Be(1, "GetEqualityComponents should return exactly one component.");
        components[0].Should().Be(guid, "The component should be the GUID value of the ProductId.");
    }

    [Fact]
    public void Test_ProductId_Operator_Equality_ReturnsTrueForEqualObjects()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var productId1 = ProductId.Create(guid);
        var productId2 = ProductId.Create(guid);

        // Act & Assert
        Assert.True(productId1 == productId2);
    }
    
    
    
    [Fact]
    public void Test_ProductId_Operator_Inequality_ReturnsTrueForDifferentObjects()
    {
        // Arrange
        var productId1 = ProductId.Create(Guid.NewGuid());
        var productId2 = ProductId.Create(Guid.NewGuid());

        // Act & Assert
        Assert.True(productId1 != productId2);
    }
    
    
    [Fact]
    public void Test_ProductId_GetHashCode_ReturnsDifferentHashCodeForDifferentObjects()
    {
        // Arrange
        var productId1 = ProductId.Create(Guid.NewGuid());
        var productId2 = ProductId.Create(Guid.NewGuid());

        // Act
        var hashCode1 = productId1.GetHashCode();
        var hashCode2 = productId2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
    
    
    
    [Fact]
    public void Test_ProductId_Equals_ReturnsTrueForEqualObjects()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var productId1 = ProductId.Create(guid);
        var productId2 = ProductId.Create(guid);

        // Act
        var areEqual = productId1.Equals(productId2);

        // Assert
        Assert.True(areEqual);
    }
    
    
    
    [Fact]
    public void Test_ProductId_Equals_ReturnsFalseForDifferentObjects()
    {
        // Arrange
        var productId1 = ProductId.Create(Guid.NewGuid());
        var productId2 = ProductId.Create(Guid.NewGuid());

        // Act
        var areEqual = productId1.Equals(productId2);

        // Assert
        Assert.False(areEqual);
    }
}