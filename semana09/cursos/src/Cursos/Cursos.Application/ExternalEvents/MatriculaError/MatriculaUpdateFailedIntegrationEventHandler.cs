using Cursos.Domain.Cursos;
using MediatR;

namespace Cursos.Application.ExternalEvents.Matriculas.MatriculaError;

internal sealed class MatriculaUpdateFailedIntegrationEventHandler : INotificationHandler<MatriculaUpdateFailedIntegrationEvent>
{
    private readonly ICursoRepository _cursoRepository;

    public MatriculaUpdateFailedIntegrationEventHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task Handle(MatriculaUpdateFailedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var curso = await _cursoRepository.GetByIdAsync(notification.CursoId, cancellationToken);

        if (curso is null)
        {
            return;
        }

        curso.AumentarCapacidad();

        await _cursoRepository.UpdateAsync(notification.CursoId, curso, cancellationToken);
    }
}