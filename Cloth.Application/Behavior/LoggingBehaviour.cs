using Cloth.Application.Extensions;
using Cloth.Application.Models.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cloth.Application.Behavior;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ClothFilterDto
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            LoggingExtensions.LogSendRequest(_logger, typeof(TRequest).Name, DateTime.Now);

            var result = await next();

            LoggingExtensions.LogCompleteRequest(_logger, typeof(TRequest).Name, DateTime.Now);

            return result;
        }
        catch (Exception ex)
        {
            LoggingExtensions.LogErrorRequest(_logger, typeof(TRequest).Name, ex.Message, DateTime.Now);
            throw;
        }
    }
}