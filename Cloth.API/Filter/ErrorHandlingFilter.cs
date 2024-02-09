using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using Cloth.API.Models;

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

        context.Result = new JsonResult(error);
        context.ExceptionHandled = true;
    }
}
