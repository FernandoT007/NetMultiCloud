using Docentes.Domain.Abstractions;
using Docentes.Domain.Docentes;

namespace Docentes.Domain.CursosImpartidos;

public sealed class CursoImpartido : Entity
{
    private CursoImpartido() { }
    public CursoImpartido(
        Guid id,
        Guid? docenteId,
        Guid? cursoId) : base(id)
    {
        Id = id;
        DocenteId = docenteId;
        CursoId = cursoId;
    } 
    public Guid? DocenteId { get; set; }
    public Guid? CursoId { get; set; }
    public Docente? Docente { get; set; }
    
}