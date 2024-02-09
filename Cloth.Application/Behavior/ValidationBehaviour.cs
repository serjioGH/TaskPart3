using Cloth.Application.Extensions;
using Cloth.Application.Models.Dto;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloth.Application.Behavior;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    where TResponse : ClothTask1Dto
{
    private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
    private readonly IValidator<TRequest> _validator;

    public ValidationBehaviour(IValidator<TRequest> validator, ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            LoggingExtensions.LogRequestFailedValidation(_logger);
            throw new ValidationException(result.Errors);
        }

        return await next();
    }
}