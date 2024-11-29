namespace Cursos.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(){}

    protected Entity(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; init; }
}