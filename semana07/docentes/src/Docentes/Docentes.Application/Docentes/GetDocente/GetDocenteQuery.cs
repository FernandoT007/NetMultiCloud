using Docentes.Application.Abstractions.Messaging;

namespace Docentes.Application.Docentes.GetDocente;

public sealed record GetDocenteQuery(Guid DocenteId) : IQuery<DocenteResponse>;