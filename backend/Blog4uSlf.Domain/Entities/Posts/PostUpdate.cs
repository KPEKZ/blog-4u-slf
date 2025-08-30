namespace Blog4uSlf.Domain.Entities.Posts;

/// <summary>
/// Represents a update blog post entity.
/// </summary>
public class PostUpdate
{
  /// <summary>
  /// Gets or sets the title of the post.
  /// </summary>
  public string Title { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the content of the post.
  /// </summary>
  public string Content { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the URL-friendly slug for the post.
  /// </summary>
  public string? Slug { get; set; }

}
