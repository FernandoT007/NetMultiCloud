using MediatR;
using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Application.Abstractions.Messaging;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
    
}