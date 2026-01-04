namespace Blog4uSlf.Domain.Enums.Posts;

/// <summary>
/// Represents the available fields for filtering blog posts.
/// </summary>
/// <remarks>
/// This enum defines the fields that can be used as filtering criteria when querying posts.
/// </remarks>
public enum PostFilterField: byte
{
  Title = 0,
  Content = 1,
  CreatedAt = 2,
  UpdatedAt = 3
}
