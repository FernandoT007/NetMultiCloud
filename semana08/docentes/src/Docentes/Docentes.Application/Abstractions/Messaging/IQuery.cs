using MediatR;
using Docentes.Domain.Abstractions;

namespace Docentes.Application.Abstractions.Messaging;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
    
}