using Cursos.Domain.Cursos;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Cursos.Infrastructure.Serializers;

public class NombreCursoSerializer : SerializerBase<NombreCurso>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, NombreCurso value)
    {
        context.Writer.WriteString(value.Value);
    }

    public override NombreCurso Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return new NombreCurso(value);
    }
}