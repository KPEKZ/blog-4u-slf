namespace Blog4uSlf.Application.Dto;

public sealed record PostCreateDto(string Title,
  string Content,
  string Slug);
