using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Diagram.RelationalModel.HashCodes;
using Pure.Primitives.Abstractions.Serialization.System;
using Pure.Primitives.Random.String;
using Char = Pure.Primitives.Char.Char;
using Guid = Pure.Primitives.Guid.Guid;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System.Tests;

public sealed record DiagramSeriesRelationalModelConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DiagramSeriesRelationalModelConverterTests()
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
        Guid diagramId = new Guid();
        RandomString label = new RandomString(new Char('a'), new Char('z'));
        RandomString source = new RandomString(new Char('a'), new Char('z'));

        IDiagramSeriesRelationalModel series = new DiagramSeriesRelationalModel(
            id,
            diagramId,
            label,
            source
        );

        string serialized = JsonSerializer.Serialize(series, _options);

        Assert.Equal(
            $$"""
            {
              "Id": "{{id.GuidValue}}",
              "DiagramId": "{{diagramId.GuidValue}}",
              "Label": "{{label.TextValue}}",
              "Source": "{{source.TextValue}}"
            }
            """,
            serialized
        );
    }

    [Fact]
    public void Read()
    {
        Guid id = new Guid();
        Guid diagramId = new Guid();
        RandomString label = new RandomString(new Char('a'), new Char('z'));
        RandomString source = new RandomString(new Char('a'), new Char('z'));

        IDiagramSeriesRelationalModel expected = new DiagramSeriesRelationalModel(
            id,
            diagramId,
            label,
            source
        );

        string input = $$"""
            {
              "Id": "{{id.GuidValue}}",
              "DiagramId": "{{diagramId.GuidValue}}",
              "Label": "{{label.TextValue}}",
              "Source": "{{source.TextValue}}"
            }
            """;

        Assert.True(
            new DiagramSeriesRelationalModelHash(expected).SequenceEqual(
                new DiagramSeriesRelationalModelHash(
                    JsonSerializer.Deserialize<IDiagramSeriesRelationalModel>(
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
        IDiagramSeriesRelationalModel series = new DiagramSeriesRelationalModel(
            new Guid(),
            new Guid(),
            new RandomString(new Char('a'), new Char('z')),
            new RandomString(new Char('a'), new Char('z'))
        );

        IDiagramSeriesRelationalModel deserialized =
            JsonSerializer.Deserialize<IDiagramSeriesRelationalModel>(
                JsonSerializer.Serialize(series, _options),
                _options
            )!;

        Assert.True(
            new DiagramSeriesRelationalModelHash(series).SequenceEqual(
                new DiagramSeriesRelationalModelHash(deserialized)
            )
        );
    }
}
