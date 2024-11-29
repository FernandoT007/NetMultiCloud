using Cursos.Domain.Abstractions;
using MediatR;

namespace Cursos.Application.Abstractions.Messaging;

public interface ICommand: IRequest<Result>, IBaseCommand
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{

}

public interface IBaseCommand
{

}