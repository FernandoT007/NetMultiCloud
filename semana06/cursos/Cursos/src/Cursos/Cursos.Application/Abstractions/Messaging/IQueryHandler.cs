using Cursos.Domain.Abstractions;
using MediatR;

namespace Cursos.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery,TResponse> 
: IRequestHandler<TQuery,Result<TResponse>>
where TQuery : IQuery<TResponse>
{
}