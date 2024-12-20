using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Domain.Programaciones;

public sealed class Programacion : Entity
{
    private Programacion(
        Guid id,
        Guid cursoId, 
        Guid docenteId, 
        ProgramacionEstados estado, 
        DateTime fechaUltimoCambio) : base(id)
    {
        CursoId = cursoId;
        DocenteId = docenteId;
        Estado = estado;
        FechaUltimoCambio = fechaUltimoCambio;
    }
    private Programacion() { }

    public Guid CursoId { get; private set; }
    public Guid DocenteId { get; private set; }
    public ProgramacionEstados Estado { get; private set; }
    public DateTime FechaUltimoCambio { get; private set; }

    public static Programacion Create(
        Guid cursoId, 
        Guid docenteId, 
        DateTime fechaCreacion
    )
    {
        var programacion = new Programacion(
            Guid.NewGuid(),
            cursoId,
            docenteId,
            ProgramacionEstados.Abierto,
            fechaCreacion
        );
        return programacion;
    }

}