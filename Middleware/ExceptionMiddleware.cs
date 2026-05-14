using final_crud.Middleware;
using Microsoft.AspNetCore.Diagnostics;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred");

            int statusCode = 500;
            string message = "Something went wrong";

            if (ex is AppException appEx)
            {
                statusCode = appEx.StatusCode;
                message = appEx.Message;
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                message = message
            });
        }
    }
}