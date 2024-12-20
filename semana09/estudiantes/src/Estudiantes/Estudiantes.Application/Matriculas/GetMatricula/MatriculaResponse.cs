namespace Estudiantes.Application.Matriculas.GetMatricula;

public sealed record MatriculaResponse
(
    Guid Id,
    Guid EstudianteId,
    Guid ProgramacionId,
    DateTime FechaMatricula,
    string Estado
);