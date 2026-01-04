namespace Blog4uSlf.Domain.Enums.Posts;

/// <summary>
/// Represents the available sort fields for posts.
/// </summary>
public enum PostSortField: byte
{
  /// <summary>
  /// Sort by post title.
  /// </summary>
  Title = 0,

  /// <summary>
  /// Sort by post creation date.
  /// </summary>
  CreatedAt = 1,

  /// <summary>
  /// Sort by post update date.
  /// </summary>
  UpdatedAt = 2
}
