using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Programaciones.GetProgramacion;

public sealed record GetProgramacionQuery (Guid ProgramacionId) : IQuery<ProgramacionResponse>;