namespace Blog4uSlf.Web.Dtos.Posts;

/// <summary>
/// Represents a data transfer object for a blog post.
/// </summary>
/// <param name="Id">The unique identifier of the post.</param>
/// <param name="Title">The title of the post.</param>
/// <param name="Content">The content body of the post.</param>
/// <param name="Slug">The URL-friendly slug for the post.</param>
/// <param name="CreatedAt">The date and time when the post was created.</param>
/// <param name="UpdatedAt">The date and time when the post was last updated.</param>
public sealed record PostDto(Guid Id,
  string Title,
  string Content,
  string Slug,
  DateTime CreatedAt,
  DateTime UpdatedAt);
