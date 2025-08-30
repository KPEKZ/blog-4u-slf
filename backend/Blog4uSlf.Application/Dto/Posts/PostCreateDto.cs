namespace Blog4uSlf.Application.Dto.Posts;

public sealed record PostCreateDto(string Title,
  string Content,
  string Slug);
