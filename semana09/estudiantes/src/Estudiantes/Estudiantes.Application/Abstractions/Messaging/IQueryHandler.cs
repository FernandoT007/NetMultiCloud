using MediatR;
using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> 
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{
    
}