using MediatR;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}