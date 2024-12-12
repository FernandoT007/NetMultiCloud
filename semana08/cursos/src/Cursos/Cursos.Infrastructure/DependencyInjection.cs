using Cursos.Domain.Cursos;
using Cursos.Infrastructure.Repositories;
using Cursos.Infrastructure.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Cursos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var setting = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>() ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton<IMongoClient,MongoClient>( sp => 
        {
             return new MongoClient(setting.ConnectionString);
        });

        services.AddScoped( sp =>
        {
           var client = sp.GetRequiredService<IMongoClient>();
           return client.GetDatabase(setting.DatabaseName); 
        });

        services.AddScoped<IMongoCollection<Curso>>( sp =>
        {
           var database = sp.GetRequiredService<IMongoDatabase>();
           return database.GetCollection<Curso>("Cursos");
        });


        services.AddScoped<ICursoRepository,CursoRepository>();

        BsonSerializer.RegisterSerializer(new CapacidadCursoSerializer());
        BsonSerializer.RegisterSerializer(new DescripcionCursoSerializer());
        BsonSerializer.RegisterSerializer(new NombreCursoSerializer());

        return services;
    }
}