using Cursos.Domain.Abstractions;
using MediatR;

namespace Cursos.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}