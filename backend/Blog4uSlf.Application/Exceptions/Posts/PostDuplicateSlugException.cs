namespace Blog4uSlf.Application.Exceptions.Posts;

public sealed class PostDuplicateSlugException : AppException
{
  public PostDuplicateSlugException(string slug, Exception? innerException) : base($"Post with slug '{slug}' already exists.",
  innerException,
  409)
  { }

  public PostDuplicateSlugException(string slug) : base($"Post with slug '{slug}' already exists.", 409) { }
}
