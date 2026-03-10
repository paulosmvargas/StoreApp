using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
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
            await WriteProblemDetails(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (InvalidOperationException ex)
        {
            await WriteProblemDetails(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception)
        {
            await WriteProblemDetails(context, "Erro interno no servidor", HttpStatusCode.InternalServerError);
        }
    }

    private static async Task WriteProblemDetails(HttpContext context, string message, HttpStatusCode status)
    {
        context.Response.StatusCode = (int)status;
        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails
        {
            Title = message,
            Status = (int)status
        };

        await context.Response.WriteAsJsonAsync(problem);
    }
}