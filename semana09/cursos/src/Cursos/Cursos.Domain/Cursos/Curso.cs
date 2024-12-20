using Cursos.Domain.Abstractions;

namespace Cursos.Domain.Cursos;

public class Curso : Entity
{
    private Curso(
        Guid id,
        NombreCurso nombreCurso, 
        DescripcionCurso? descripcionCurso, 
        CapacidadCurso? capacidadCurso) : base(id)
    {
        NombreCurso = nombreCurso;
        DescripcionCurso = descripcionCurso;
        CapacidadCurso = capacidadCurso;
    }

    private Curso() {}

    public NombreCurso?  NombreCurso { get; private set; }
    public DescripcionCurso? DescripcionCurso { get; private set; }
    public CapacidadCurso? CapacidadCurso { get; private set; }

    public static Curso Create(
        NombreCurso nombreCurso, 
        DescripcionCurso? descripcionCurso, 
        CapacidadCurso? capacidadCurso
    )
    {
        return new Curso(Guid.NewGuid(),nombreCurso,descripcionCurso,capacidadCurso);
    }

   public void RestarCapacidad()
    {
        if (CapacidadCurso!.Value <= 0)
        {
            throw new InvalidOperationException("La capacidad del curso ya es cero.");
        }
        CapacidadCurso = new CapacidadCurso(CapacidadCurso.Value - 1);
    }
    public void AumentarCapacidad()
    {
        CapacidadCurso = new CapacidadCurso(CapacidadCurso!.Value + 1);
    }
    public bool TieneCuposDisponibles()
    {
        return CapacidadCurso!.Value > 0;
    }
}