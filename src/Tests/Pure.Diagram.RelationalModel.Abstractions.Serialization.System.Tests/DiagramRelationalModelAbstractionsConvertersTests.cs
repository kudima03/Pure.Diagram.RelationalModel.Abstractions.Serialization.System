using System.Collections;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System.Tests;

public sealed record DiagramRelationalModelAbstractionsConvertersTests
{
    [Fact]
    public void EnumeratesThreeConverters()
    {
        Assert.Equal(3, new DiagramRelationalModelAbstractionsConverters().Count());
    }

    [Fact]
    public void NonGenericEnumeratorReturnsAllConverters()
    {
        IEnumerable converters = new DiagramRelationalModelAbstractionsConverters();

        int count = 0;

        foreach (object _ in converters)
        {
            count++;
        }

        Assert.Equal(3, count);
    }
}
