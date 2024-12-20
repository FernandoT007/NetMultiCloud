using FluentValidation;
using MediatR;
using Estudiantes.Application.Exceptions;
using Estudiantes.Application.Abstractions.Messaging;

namespace Estudiantes.Application.Abstractions.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
: IPipelineBehavior<TRequest, TResponse>
where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if(!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationErrores = _validators
        .Select( validators => validators.Validate(context))
        .Where( validationsResult => validationsResult.Errors.Any())
        .SelectMany( validationResult => validationResult.Errors)
        .Select(
         validatorsFailure => new ValidationError (
            validatorsFailure.PropertyName,
            validatorsFailure.ErrorMessage
        )).ToList();

        if(validationErrores.Any())
        {
            throw new Exceptions.ValidationExceptions(validationErrores);
        }
        return await next();

    }
}
