using Cloth.Application.Queries;
using Microsoft.Extensions.Logging;

namespace Cloth.Application.Extensions;

public static partial class LoggingExtensions
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Sending request {RequestName}, {DateTimeNow}")]
    public static partial void LogSendRequest(this ILogger logger, string RequestName, DateTime DateTimeNow);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Completed request {RequestName}, {DateTimeNow}")]
    public static partial void LogCompleteRequest(this ILogger logger, string RequestName, DateTime DateTimeNow);

    [LoggerMessage(EventId = 3, Level = LogLevel.Error, Message = "{RequestName} resulted in error with Exception: {Message}, {DateTimeNow}")]
    public static partial void LogErrorRequest(this ILogger logger, string RequestName, string Message, DateTime DateTimeNow);

    [LoggerMessage(EventId = 4, Level = LogLevel.Error, Message = "Request Validation Failed.")]
    public static partial void LogRequestFailedValidation(this ILogger logger);

    [LoggerMessage(EventId = 5, Level = LogLevel.Information, Message = "Getting Cloths from the database")]
    public static partial void LogGettingCloths(this ILogger logger);

    [LoggerMessage(EventId = 6, Level = LogLevel.Error, Message = "Failed to receive items from the database.")]
    public static partial void LogErrorGettingCloths(this ILogger logger);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information, Message = "Cloths filtered.")]
    public static partial void LogFilteringProducts(this ILogger logger);

    [LoggerMessage(EventId = 8, Level = LogLevel.Information, Message = "Handler with request: {ClothQuery}")]
    public static partial void LogRequestHandlerMessage(this ILogger logger, ClothQuery ClothQuery);

}