using Docentes.Domain.Docentes;
using Microsoft.EntityFrameworkCore;

namespace Docentes.Infrastructure.Repositories;

internal sealed class DocenteRepository : Repository<Docente>, IDocenteRepository
{
    public DocenteRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Docente?> GetByIdUsuarioAsync(Guid idUsuario, CancellationToken cancellationToken = default)
    {
       return await DbContext.Set<Docente>().FirstOrDefaultAsync(
            docente => docente.UsuarioId == idUsuario, cancellationToken
        );
    }
}