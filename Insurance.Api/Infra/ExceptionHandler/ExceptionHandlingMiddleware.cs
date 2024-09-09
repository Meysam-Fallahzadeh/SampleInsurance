using System.Net;
using Insurance.Domain.Dto;
using Newtonsoft.Json;

namespace Insurance.Api.Infra.ExceptionHandler;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.BadRequest);

        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex,(int)HttpStatusCode.InternalServerError);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception,int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var result = JsonConvert.SerializeObject(new ApplicationResponse(false,exception.Message));

        return context.Response.WriteAsync(result);
    }
}
