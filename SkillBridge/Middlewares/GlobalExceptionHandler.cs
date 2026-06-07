using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace SkillBridge.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var response = new
        {
            Success = false,
            Message = exception.Message
        };

        httpContext.Response.StatusCode =
            (int)HttpStatusCode.InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(response);

        return true;
    }
}
