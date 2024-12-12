using Docentes.Domain.CursosImpartidos;

namespace Docentes.Infrastructure.Repositories;

internal sealed class CursoImpartidoRepository : Repository<CursoImpartido>, ICursoImpartidoRepository
{
    public CursoImpartidoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}