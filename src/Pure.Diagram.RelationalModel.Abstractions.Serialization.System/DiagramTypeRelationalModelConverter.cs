using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System;

internal sealed record DiagramTypeRelationalModelJsonModel : IDiagramTypeRelationalModel
{
    public DiagramTypeRelationalModelJsonModel(IDiagramTypeRelationalModel model)
        : this(model.Id, model.Name) { }

    [JsonConstructor]
    public DiagramTypeRelationalModelJsonModel(IGuid id, IString name)
    {
        Id = id;
        Name = name;
    }

    public IGuid Id { get; }

    public IString Name { get; }
}

public sealed class DiagramTypeRelationalModelConverter
    : JsonConverter<IDiagramTypeRelationalModel>
{
    public override IDiagramTypeRelationalModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<DiagramTypeRelationalModelJsonModel>(
            ref reader,
            options
        )!;
    }

    public override void Write(
        Utf8JsonWriter writer,
        IDiagramTypeRelationalModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            new DiagramTypeRelationalModelJsonModel(value),
            options
        );
    }
}
