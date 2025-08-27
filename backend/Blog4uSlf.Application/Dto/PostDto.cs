namespace Blog4uSlf.Application.Dto;

public sealed record PostDto(Guid Id,
  string Title,
  string Content,
  string Slug,
  DateTime CreatedAt,
  DateTime UpdatedAt,
  Guid AuthorId);
