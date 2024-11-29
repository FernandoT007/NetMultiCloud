using Cursos.Application.Abstractions.Messaging;

namespace Cursos.Application.Cursos.ObtenerCurso;

public sealed record GetCursoQuery(Guid cursoId) : IQuery<CursoResponse>;