using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Matriculas.GetMatricula;

public sealed record GetMatriculaQuery(Guid MatriculaId) : IQuery<MatriculaResponse>;