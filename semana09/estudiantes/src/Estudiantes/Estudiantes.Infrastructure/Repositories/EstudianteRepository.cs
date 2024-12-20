using Estudiantes.Domain.Estudiantes;

namespace Estudiantes.Infrastructure.Repositories;

internal sealed class EstudianteRepository : Repository<Estudiante>, IEstudianteRepository
{
    public EstudianteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}