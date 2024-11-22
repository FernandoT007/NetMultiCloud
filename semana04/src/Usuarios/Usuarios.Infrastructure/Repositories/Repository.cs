using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Infrastructure.Repositories;

internal abstract class Repository<T>
where T : Entity
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> ListAsync(
        CancellationToken cancellationToken
    )
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(
        Guid Id,
        CancellationToken cancellationToken
    )
    {
        return await _dbContext.Set<T>()
        .FirstOrDefaultAsync(entity => entity.Id == Id, cancellationToken);
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Remove(entity);
    }
}