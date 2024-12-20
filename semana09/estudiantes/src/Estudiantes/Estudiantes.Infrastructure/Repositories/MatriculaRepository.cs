using Estudiantes.Domain.Matriculas;
using Microsoft.EntityFrameworkCore;

namespace Estudiantes.Infrastructure.Repositories;

internal sealed class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
{
    public MatriculaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<Matricula?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Matricula>()
            .Include(m => m.Programacion)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

}