using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System;

internal sealed record DiagramSeriesRelationalModel : IDiagramSeriesRelationalModel
{
    public DiagramSeriesRelationalModel(IDiagramSeriesRelationalModel model)
        : this(model.Id, model.DiagramId, model.Label, model.Source) { }

    [JsonConstructor]
    public DiagramSeriesRelationalModel(
        IGuid id,
        IGuid diagramId,
        IString label,
        IString source
    )
    {
        Id = id;
        DiagramId = diagramId;
        Label = label;
        Source = source;
    }

    public IGuid Id { get; }

    public IGuid DiagramId { get; }

    public IString Label { get; }

    public IString Source { get; }
}

public sealed class DiagramSeriesRelationalModelConverter
    : JsonConverter<IDiagramSeriesRelationalModel>
{
    public override IDiagramSeriesRelationalModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<DiagramSeriesRelationalModel>(
            ref reader,
            options
        )!;
    }

    public override void Write(
        Utf8JsonWriter writer,
        IDiagramSeriesRelationalModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            new DiagramSeriesRelationalModel(value),
            options
        );
    }
}
