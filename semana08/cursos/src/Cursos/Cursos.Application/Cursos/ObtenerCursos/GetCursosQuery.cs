using Cursos.Application.Abstractions.Messaging;

namespace Cursos.Application.Cursos.ObtenerCursos;

public sealed record GetCursosQuery() : IQuery<ListCursosResponse>;