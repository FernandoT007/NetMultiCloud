namespace Cursos.Infrastructure;

public record MongoDbSettings
(
    string? ConnectionString,
    string? DatabaseName
);