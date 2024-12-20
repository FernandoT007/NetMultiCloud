using MediatR;
using Estudiantes.Domain.Abstractions;

namespace Estudiantes.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result> , IBaseCommand
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>> , IBaseCommand
{

}

public interface IBaseCommand
{

}