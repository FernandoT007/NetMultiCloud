using MediatR;
using Microsoft.EntityFrameworkCore;
using Estudiantes.Application.Exceptions;
using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            await PublishDomainEventsAsync();
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
        .Entries<Entity>()
        .Select(entry => entry.Entity)
        .SelectMany(entity =>
        {
            var domainEvents = entity.GetDomainEvents();
            entity.ClearDomainEvents();
            return domainEvents;
        }).ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }

}