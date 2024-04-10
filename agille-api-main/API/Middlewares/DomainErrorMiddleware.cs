using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using AgilleApi.Domain.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.API.Middleware;

public class DomainErrorMiddleware
{
    private readonly RequestDelegate next;

    public DomainErrorMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine(exception.ToString());
        Console.WriteLine("\n\n\n\n");
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected        
        
        if (exception is NotFoundException)         code = HttpStatusCode.NotFound;
        else if (exception is BadRequestException)  code = HttpStatusCode.BadRequest;
        else if (exception is ForbiddenException)   code = HttpStatusCode.Forbidden;
        else if (exception is ConflictException)    code = HttpStatusCode.Conflict;

        var errorResponse = code != HttpStatusCode.InternalServerError ? exception.Message : "Unknown error";

        var messagesAux = new List<string>();
        if (exception is DomainException domainException)  
            messagesAux.AddRange(domainException.ValidationMessages);
        var messages = messagesAux.Select(e => e).Distinct();

        var result = JsonConvert.SerializeObject(new { error = errorResponse, validationMessages = messages });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}