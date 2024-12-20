using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Estudiantes;
using Estudiantes.Domain.Matriculas.Events;
using Estudiantes.Domain.Programaciones;

namespace Estudiantes.Domain.Matriculas;

public sealed class Matricula : Entity
{
    private Matricula(
        Guid id,
        Guid estudianteId,
        Guid programacionId,
        DateTime fechaMatricula,
        MatriculaEstados estadoMatricula
        ) : base(id)
    {
        EstudianteId = estudianteId;
        ProgramacionId = programacionId;
        FechaMatricula = fechaMatricula;
        EstadoMatricula = estadoMatricula;
    }

    public Guid EstudianteId { get; private set; }
    public Estudiante? Estudiante { get; private set; }
    public Guid ProgramacionId { get; private set; }
    public Programacion? Programacion { get; private set; }
    public DateTime FechaMatricula { get; private set; }
    public MatriculaEstados EstadoMatricula { get; private set; }
    public static Result<Matricula> Create(
       Guid estudianteId,
       Guid programacionId,
       DateTime fechaMatricula
    )
    {
        var matricula = new Matricula(
            Guid.NewGuid(),
            estudianteId,
            programacionId,
            fechaMatricula,
            MatriculaEstados.PENDIENTE
        );

        matricula.RaiseDomainEvent(new MatriculaCreateDomainEvent(matricula.Id));

        return matricula;
    }

    public void ActualizarEstado(MatriculaEstados nuevoEstado)
    {
        EstadoMatricula = nuevoEstado;
    }
}