using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Infrastructure.Repositories;

internal sealed class ProgramacionRepository : Repository<Programacion>, IProgramacionRepository
{
    public ProgramacionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}