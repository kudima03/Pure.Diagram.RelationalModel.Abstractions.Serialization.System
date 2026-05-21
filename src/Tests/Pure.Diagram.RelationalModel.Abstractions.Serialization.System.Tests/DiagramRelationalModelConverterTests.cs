using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Diagram.RelationalModel.HashCodes;
using Pure.Primitives.Abstractions.Serialization.System;
using Pure.Primitives.Random.String;
using Char = Pure.Primitives.Char.Char;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System.Tests;

public sealed record DiagramRelationalModelConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DiagramRelationalModelConverterTests()
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
        RandomString title = new RandomString(new Char('a'), new Char('z'));
        RandomString description = new RandomString(new Char('a'), new Char('z'));
        Guid typeId = new Guid();

        IDiagramRelationalModel diagram = new DiagramRelationalModel(
            id,
            title,
            description,
            typeId
        );

        string serialized = JsonSerializer.Serialize(diagram, _options);

        Assert.Equal(
            $$"""
            {
              "Id": "{{id.GuidValue}}",
              "Title": "{{title.TextValue}}",
              "Description": "{{description.TextValue}}",
              "TypeId": "{{typeId.GuidValue}}"
            }
            """,
            serialized
        );
    }

    [Fact]
    public void Read()
    {
        Guid id = new Guid();
        RandomString title = new RandomString(new Char('a'), new Char('z'));
        RandomString description = new RandomString(new Char('a'), new Char('z'));
        Guid typeId = new Guid();

        IDiagramRelationalModel expected = new DiagramRelationalModel(
            id,
            title,
            description,
            typeId
        );

        string input = $$"""
            {
              "Id": "{{id.GuidValue}}",
              "Title": "{{title.TextValue}}",
              "Description": "{{description.TextValue}}",
              "TypeId": "{{typeId.GuidValue}}"
            }
            """;

        Assert.True(
            new DiagramRelationalModelHash(expected).SequenceEqual(
                new DiagramRelationalModelHash(
                    JsonSerializer.Deserialize<IDiagramRelationalModel>(input, _options)!
                )
            )
        );
    }

    [Fact]
    public void RoundTrip()
    {
        IDiagramRelationalModel diagram = new DiagramRelationalModel(
            new Guid(),
            new RandomString(new Char('a'), new Char('z')),
            new RandomString(new Char('a'), new Char('z')),
            new Guid()
        );

        IDiagramRelationalModel deserialized =
            JsonSerializer.Deserialize<IDiagramRelationalModel>(
                JsonSerializer.Serialize(diagram, _options),
                _options
            )!;

        Assert.True(
            new DiagramRelationalModelHash(diagram).SequenceEqual(
                new DiagramRelationalModelHash(deserialized)
            )
        );
    }
}
