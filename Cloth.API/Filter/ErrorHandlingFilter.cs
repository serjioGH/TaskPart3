using AutoMapper;
using Cloth.API.Models;
using Cloth.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Cloth.API.Filter;

public class ErrorHandlingFilter : IExceptionFilter
{
    public static Error HandleException(Exception exception) => exception switch
    {
        AutoMapperMappingException => new Error { StatusCode = HttpStatusCode.BadRequest, Message = exception.Message },
        ArgumentNullException => new Error { StatusCode = HttpStatusCode.BadRequest, Message = exception.Message },
        InvalidOperationException => new Error { StatusCode = HttpStatusCode.InternalServerError, Message = exception.Message },
        ItemNotFoundException => new Error { StatusCode = HttpStatusCode.BadRequest, Message = exception.Message },
        _ => new Error { StatusCode = HttpStatusCode.InternalServerError, Message = "Unexpected error occured." },
    };

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var error = HandleException(exception);

        context.Result = new JsonResult(error);
        context.ExceptionHandled = true;
    }
}