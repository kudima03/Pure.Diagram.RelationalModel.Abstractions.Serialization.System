using System.Text.Json;
using System.Text.Json.Serialization;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Diagram.RelationalModel.Abstractions.Serialization.System;

internal sealed record DiagramRelationalModel : IDiagramRelationalModel
{
    public DiagramRelationalModel(IDiagramRelationalModel model)
        : this(model.Id, model.Title, model.Description, model.TypeId) { }

    [JsonConstructor]
    public DiagramRelationalModel(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TypeId = typeId;
    }

    public IGuid Id { get; }

    public IString Title { get; }

    public IString Description { get; }

    public IGuid TypeId { get; }
}

public sealed class DiagramRelationalModelConverter
    : JsonConverter<IDiagramRelationalModel>
{
    public override IDiagramRelationalModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<DiagramRelationalModel>(ref reader, options)!;
    }

    public override void Write(
        Utf8JsonWriter writer,
        IDiagramRelationalModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, new DiagramRelationalModel(value), options);
    }
}
