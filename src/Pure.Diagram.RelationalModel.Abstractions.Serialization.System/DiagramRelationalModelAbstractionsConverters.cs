using System.Collections;
using System.Text.Json.Serialization;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System;

public sealed record DiagramRelationalModelAbstractionsConverters
    : IEnumerable<JsonConverter>
{
    public IEnumerator<JsonConverter> GetEnumerator()
    {
        yield return new DiagramTypeRelationalModelConverter();
        yield return new DiagramSeriesRelationalModelConverter();
        yield return new DiagramRelationalModelConverter();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
