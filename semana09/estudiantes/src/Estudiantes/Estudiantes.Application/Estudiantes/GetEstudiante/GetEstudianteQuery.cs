using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Estudiantes.GetEstudiante;

public sealed record GetEstudianteQuery(Guid EstudianteId) : IQuery<EstudianteResponse>;