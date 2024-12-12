using Cursos.Domain.Cursos;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Cursos.Infrastructure.Serializers;

public class DescripcionCursoSerializer : SerializerBase<DescripcionCurso>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DescripcionCurso capacidad)
    {
       context.Writer.WriteString(capacidad.Value);
    }

    public override DescripcionCurso Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return new DescripcionCurso(value);
    }
}