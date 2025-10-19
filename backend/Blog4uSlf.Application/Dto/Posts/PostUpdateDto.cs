namespace Blog4uSlf.Application.Dto.Posts;

/// <summary>
/// Data Transfer Object for updating a blog post.
/// </summary>
/// <param name="Title">The updated title of the post. Optional.</param>
/// <param name="Content">The updated content of the post. Optional.</param>
/// <param name="Slug">The updated URL-friendly slug for the post. Optional.</param>
public readonly record struct PostUpdateDto(string? Title,
  string? Content,
  string? Slug
);
