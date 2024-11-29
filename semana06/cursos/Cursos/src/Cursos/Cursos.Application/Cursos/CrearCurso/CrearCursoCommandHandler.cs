using Cursos.Application.Abstractions.Messaging;
using Cursos.Domain.Abstractions;
using Cursos.Domain.Cursos;

namespace Cursos.Application.Cursos.CrearCurso;

internal sealed class CrearCursoCommandHandler : ICommandHandler<CrearCursoCommand, Guid>
{
    private readonly ICursoRepository _cursoRepository;

    public CrearCursoCommandHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<Result<Guid>> Handle(CrearCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = Curso.Create(
            new NombreCurso(request.NombreCurso),
            new DescripcionCurso(request.DescripcionCurso),
            new CapacidadCurso(request.CapacidadCurso)
        );

        await _cursoRepository.AddAsync(curso);
        
        return Result.Success(curso.Id);
    }
}