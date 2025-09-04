namespace Blog4uSlf.Application.Exceptions;

public class AppException : Exception
{
  public int? StatusCode { get; }

  public AppException() : base() { }

  public AppException(string message) : base(message) { }

  public AppException(string? message, Exception? innerException) : base(message, innerException) { }

  public AppException(string? message, int? statusCode) : base(message)
  {
    StatusCode = statusCode;
  }

  public AppException(string? message, Exception? innerException, int? statusCode) : base(message, innerException)
  {
    StatusCode = statusCode;
  }
}
