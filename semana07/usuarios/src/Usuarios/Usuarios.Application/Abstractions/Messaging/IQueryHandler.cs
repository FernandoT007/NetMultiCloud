using MediatR;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery,Result<TResponse>>
where TQuery : IQuery<TResponse>
{
    
}