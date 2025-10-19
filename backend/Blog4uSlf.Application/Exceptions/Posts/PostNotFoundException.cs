namespace Blog4uSlf.Application.Exceptions.Posts;

public sealed class PostNotFoundException : AppException
{

  public PostNotFoundException(Guid id) : base($"Post with id {id} not found", 404) { }

  public PostNotFoundException(Guid id, Exception? innerException) : base($"Post with id {id} not found",
    innerException,
    404)
  { }

}
