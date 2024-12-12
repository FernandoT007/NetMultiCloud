namespace Docentes.Application.Docentes.GetDocente;

public sealed record DocenteResponse
(
    Guid Id,
    Guid UsuarioId,
    Guid EspecialidadID
);