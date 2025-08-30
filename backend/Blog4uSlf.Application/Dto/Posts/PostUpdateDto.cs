namespace Blog4uSlf.Application.Dto.Posts;

public sealed record PostUpdateDto(string Title,
  string Content,
  string Slug
);
