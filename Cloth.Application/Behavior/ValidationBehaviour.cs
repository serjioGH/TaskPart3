using Cloth.Application.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloth.Application.Behavior;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator, ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var results = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(request, cancellationToken)));
        var errors = results.SelectMany(v => v.Errors).Where(err => err != null).ToList();
        if (errors.Any())
        {
            LoggingExtensions.LogRequestFailedValidation(_logger);
            throw new ValidationException(errors);
        }

        return await next();
    }
}