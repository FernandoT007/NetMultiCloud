using Cursos.Domain.Cursos;
using MongoDB.Driver;

namespace Cursos.Infrastructure.Repositories;

public class CursoRepository : Repository<Curso>, ICursoRepository
{
    public CursoRepository(IMongoCollection<Curso> collection) : base(collection)
    {
    }

    public async Task<List<Curso>> GetCursos(CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }
}