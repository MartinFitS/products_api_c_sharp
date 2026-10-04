using ProductsShop.Domain.Entities.Exceptions;
using System.Net;
using System.Text.Json;

namespace ProductsShopWebApi.Middlewares;

public class ExceptionsHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionsHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }catch(Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = string.Empty;

        switch (exception)
        {
            case NegotionRule_Exception negotionRule_Exception:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(negotionRule_Exception.Message);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(result);
    }
}

public static class HandlerExceptionsMiddlewareExtensions
{
    public static IApplicationBuilder ExceptionHandlerUse(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionsHandlerMiddleware>();
    }
}