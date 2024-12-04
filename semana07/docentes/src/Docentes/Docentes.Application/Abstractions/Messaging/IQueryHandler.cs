using MediatR;
using Docentes.Domain.Abstractions;

namespace Docentes.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> 
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{
    
}