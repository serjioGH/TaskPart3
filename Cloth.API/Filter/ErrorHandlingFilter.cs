using AutoMapper;
using Cloth.API.Models;
using Cloth.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Cloth.API.Filter;

public class ErrorHandlingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var exceptionType = exception.GetType();

        var error = new Error
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Message = exception.Message
        };

        if (exceptionType == typeof(AutoMapperMappingException))
        {
            //error.Message = "Mapping objects failed.";
            error.Message = exception.Message;
            error.StatusCode = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(ArgumentNullException))
        {
            error.Message = exception.Message;
            error.StatusCode = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(InvalidOperationException))
        {
            context.Result = new NotFoundResult();
            error.StatusCode = HttpStatusCode.InternalServerError;
            error.Message = "Internel server error.";
        }
        else if (exceptionType == typeof(ItemNotFoundException))
        {
            error.Message = exception.Message;
            error.StatusCode = HttpStatusCode.BadRequest;
        }

        context.Result = new JsonResult(error);
        context.ExceptionHandled = true;
    }
}