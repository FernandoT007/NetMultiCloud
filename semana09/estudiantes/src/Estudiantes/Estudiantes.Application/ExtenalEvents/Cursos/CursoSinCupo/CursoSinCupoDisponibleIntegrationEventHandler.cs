using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Matriculas;
using MediatR;

namespace Estudiantes.Application.ExternalEvents.Cursos.CursoSinCupo;

public class CursoSinCupoDisponibleIntegrationEventHandler: INotificationHandler<CursoSinCupoDisponibleIntegrationEvent>
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CursoSinCupoDisponibleIntegrationEventHandler(IMatriculaRepository matriculaRepository, IUnitOfWork unitOfWork)
    {
        _matriculaRepository = matriculaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CursoSinCupoDisponibleIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var matricula = await _matriculaRepository.GetByIdAsync(notification.MatriculaId, cancellationToken);

        if (matricula is null) return;

        matricula.ActualizarEstado(MatriculaEstados.RECHAZADA);
        _matriculaRepository.Update(matricula);
        await _unitOfWork.SaveChangesAsync();
    }
}