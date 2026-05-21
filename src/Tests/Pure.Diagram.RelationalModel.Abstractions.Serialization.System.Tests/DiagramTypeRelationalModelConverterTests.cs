using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Diagram.RelationalModel.HashCodes;
using Pure.Primitives.Abstractions.Serialization.System;
using Pure.Primitives.Random.String;
using Char = Pure.Primitives.Char.Char;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System.Tests;

public sealed record DiagramTypeRelationalModelConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DiagramTypeRelationalModelConverterTests()
    {
        _options = new JsonSerializerOptions();

        foreach (JsonConverter converter in new PrimitiveConverters())
        {
            _options.Converters.Add(converter);
        }

        foreach (
            JsonConverter converter in new DiagramRelationalModelAbstractionsConverters()
        )
        {
            _options.Converters.Add(converter);
        }

        _options.WriteIndented = true;
        _options.NewLine = "\n";
    }

    [Fact]
    public void Write()
    {
        Guid id = new Guid();
        RandomString name = new RandomString(new Char('a'), new Char('z'));

        IDiagramTypeRelationalModel diagramType = new DiagramTypeRelationalModel(
            id,
            name
        );

        string serialized = JsonSerializer.Serialize(diagramType, _options);

        Assert.Equal(
            $$"""
            {
              "Id": "{{id.GuidValue}}",
              "Name": "{{name.TextValue}}"
            }
            """,
            serialized
        );
    }

    [Fact]
    public void Read()
    {
        Guid id = new Guid();
        RandomString name = new RandomString(new Char('a'), new Char('z'));

        IDiagramTypeRelationalModel expected = new DiagramTypeRelationalModel(id, name);

        string input = $$"""
            {
              "Id": "{{id.GuidValue}}",
              "Name": "{{name.TextValue}}"
            }
            """;

        Assert.True(
            new DiagramTypeRelationalModelHash(expected).SequenceEqual(
                new DiagramTypeRelationalModelHash(
                    JsonSerializer.Deserialize<IDiagramTypeRelationalModel>(
                        input,
                        _options
                    )!
                )
            )
        );
    }

    [Fact]
    public void RoundTrip()
    {
        IDiagramTypeRelationalModel diagramType = new DiagramTypeRelationalModel(
            new Guid(),
            new RandomString(new Char('a'), new Char('z'))
        );

        IDiagramTypeRelationalModel deserialized =
            JsonSerializer.Deserialize<IDiagramTypeRelationalModel>(
                JsonSerializer.Serialize(diagramType, _options),
                _options
            )!;

        Assert.True(
            new DiagramTypeRelationalModelHash(diagramType).SequenceEqual(
                new DiagramTypeRelationalModelHash(deserialized)
            )
        );
    }
}
