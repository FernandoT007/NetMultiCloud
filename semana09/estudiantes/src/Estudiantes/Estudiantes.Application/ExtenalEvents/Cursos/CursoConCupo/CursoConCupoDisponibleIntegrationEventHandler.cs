using Estudiantes.Application.Matriculas.Events;
using Estudiantes.Application.Services;
using Estudiantes.Domain.Abstractions;
using Estudiantes.Domain.Matriculas;
using MediatR;

namespace Estudiantes.Application.ExternalEvents.Cursos.CursoConCupo;

internal sealed class CursoConCupoDisponibleIntegrationEventHandler : INotificationHandler<CursoConCupoDisponibleIntegrationEvent>
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventBus _eventBus;
    
    public CursoConCupoDisponibleIntegrationEventHandler(IMatriculaRepository matriculaRepository, IUnitOfWork unitOfWork, IEventBus eventBus)
    {
        _matriculaRepository = matriculaRepository;
        _unitOfWork = unitOfWork;
        _eventBus = eventBus;
    }

    public async Task Handle(CursoConCupoDisponibleIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var matricula = await _matriculaRepository.GetByIdWithDetailsAsync(notification.MatriculaId, cancellationToken);

        if (matricula is null) return;

        try
        { 
            if(matricula.ProgramacionId.ToString() == "5c950537-5019-4d3b-81d8-3583e2bac1fd") // ID de prueba, reemplazar
            {
                throw new Exception();
            }
            matricula.ActualizarEstado(MatriculaEstados.CONFIRMADA);
            _matriculaRepository.Update(matricula);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            _eventBus.Publish(new MatriculaUpdateFailedIntegrationEvent(matricula.Programacion!.CursoId));
            matricula.ActualizarEstado(MatriculaEstados.ERROR);
            _matriculaRepository.Update(matricula);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}