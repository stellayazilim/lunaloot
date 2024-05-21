using FluentAssertions;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Test.Tests.Common.Primitives;

public class ValueObjectTest
{
 
    private class TestValueObject : ValueObject
    {
        private readonly Guid _id;
        private readonly string _name;

        public TestValueObject(Guid id, string name)
        {
            _id = id;
            _name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _id;
            yield return _name;
        }
    }

    [Fact]
    public void GetEquals_ReturnsTrueForEqualObjects()
    {
        var guid = Guid.NewGuid();
        var name = "TestName";
        var obj1 = new TestValueObject(guid, name);
        var obj2 = new TestValueObject(guid, name);

        Assert.True(obj1.Equals(obj2));
    }

    
    [Fact]
    public void GetEquals_ReturnsFalseForNonEqualObjects()
    {
        var name = "TestName";
        var obj1 = new TestValueObject(Guid.NewGuid(), name);
        var obj2 = new TestValueObject(Guid.NewGuid(), name);

        Assert.False(obj1.Equals(obj2));
    }
    [Fact]
    public void GetEquals_ReturnsFalseWhenComparedWithNullObjects()
    {
        var name = "TestName";
        var obj1 = new TestValueObject(Guid.NewGuid(), name);

        Assert.False(obj1.Equals(null));
    }
    
    [Fact]
    public void GetEquals_ReturnsFalseWhenComparedWithDiffirentTypes()
    {
        var name = "TestName";
        var obj1 = new TestValueObject(Guid.NewGuid(), "name");

        Assert.False(obj1.Equals(null));
    }

    
    [Fact]
    public void GetHashCode_ReturnsSameHashCodeForEqualObjects()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var name = "TestName";
        var obj1 = new TestValueObject(guid, name);
        var obj2 = new TestValueObject(guid, name);

        // Act
        var hashCode1 = obj1.GetHashCode();
        var hashCode2 = obj2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }


    [Fact]
    public void GetHashCode_ReturnsDifferentHashCodeForDifferentObjects()
    {
        // Arrange
        var obj1 = new TestValueObject(Guid.NewGuid(), "TestName1");
        var obj2 = new TestValueObject(Guid.NewGuid(), "TestName2");

        // Act
        var hashCode1 = obj1.GetHashCode();
        var hashCode2 = obj2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
    [Fact]
    public void GetHashCode_ReturnsNonZeroForNonEmptyComponents()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var obj = new TestValueObject(guid, "TestName");

        // Act
        var hashCode = obj.GetHashCode();

        // Assert
        Assert.NotEqual(0, hashCode);
    }
    [Fact]
    public void GetHashCode_ReturnsNonZeroForEmptyComponents()
    {
        // Arrange
        var obj = new TestValueObject(Guid.Empty, string.Empty);

        // Act
        var hashCode = obj.GetHashCode();

        // Assert
        Assert.NotEqual(0, hashCode);
    }

    [Fact]
    public void GetHashCode_AggregatesMultipleComponentsCorrectly()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var name = "TestName";
        var obj1 = new TestValueObject(guid, name);
        var obj2 = new TestValueObject(guid, name);

        // Act
        var hashCode1 = obj1.GetHashCode();
        var hashCode2 = obj2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
        Assert.NotEqual(0, hashCode1); // Ensure it's not zero
    }
}