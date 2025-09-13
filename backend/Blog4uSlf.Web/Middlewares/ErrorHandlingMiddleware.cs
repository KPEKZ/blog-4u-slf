using System.Text.Json;
using Blog4uSlf.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Blog4uSlf.Web.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IExceptionHandler
{
  private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {

    _logger.LogError(exception, "Unhandled exception occurred while processing request {Path}", httpContext.Request.Path);

    var problemDetails = exception switch
    {
      AppException appException => new ProblemDetails
      {
        Title = appException.Message,
        Detail = appException.InnerException?.Message,
        Status = appException.StatusCode ?? httpContext.Response.StatusCode,
        Instance = httpContext.Request.Path,
        Type = exception.GetType().Name,
      },
      _ => new ProblemDetails
      {
        Title = "An unexpected error occurred",
        Detail = exception.Message,
        Status = StatusCodes.Status500InternalServerError,
        Instance = httpContext.Request.Path,
        Type = exception.GetType().Name,
      }
    };

    await WriteErrorAsync(httpContext, problemDetails, cancellationToken);
    return true;

  }

  private static Task WriteErrorAsync(HttpContext context, ProblemDetails problemDetails, CancellationToken ct)
  {
    context.Response.StatusCode = problemDetails.Status.Value;
    context.Response.ContentType = "application/json";

    return context.Response.WriteAsJsonAsync(problemDetails, ct);
  }
}
