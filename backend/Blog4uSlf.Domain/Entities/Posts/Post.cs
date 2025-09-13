namespace Blog4uSlf.Domain.Entities.Posts;

/// <summary>
/// Represents a blog post entity.
/// </summary>
public class Post(string title, string content, string? slug)
{
  /// <summary>
  /// Gets the unique identifier for the post.
  /// </summary>
  public Guid Id { get; init; } = Guid.NewGuid();

  /// <summary>
  /// Gets or sets the title of the post.
  /// </summary>
  public string Title { get; set; } = title;

  /// <summary>
  /// Gets or sets the content of the post.
  /// </summary>
  public string Content { get; set; } = content;

  /// <summary>
  /// Gets or sets the URL-friendly slug for the post.
  /// </summary>
  public string? Slug { get; set; } = slug;

  /// <summary>
  /// Gets or sets the date and time when the post was created (in UTC).
  /// </summary>
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  /// <summary>
  /// Gets or sets the date and time when the post was last updated (in UTC).
  /// </summary>
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public Post Update(string? title, string? content, string? slug)
  {
    if (title is not null) Title = title;
    if (content is not null) Content = content;
    if (slug is not null) Slug = slug;

    UpdatedAt = DateTime.UtcNow;

    return this;
  }

  public Post() : this(string.Empty, string.Empty, null) { }
}
