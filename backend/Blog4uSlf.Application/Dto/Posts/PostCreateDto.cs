namespace Blog4uSlf.Application.Dto.Posts;

/// <summary>
/// Data Transfer Object for creating a new blog post.
/// </summary>
/// <param name="Title">The title of the blog post.</param>
/// <param name="Content">The main content of the blog post.</param>
/// <param name="Slug">A URL-friendly identifier for the blog post.</param>
public sealed record PostCreateDto(string Title,
  string Content,
  string Slug);
