namespace Blog4uSlf.Infrastructure.Persistence.Models;

public class PostDb
{
  public Guid Id { get; init; } = Guid.NewGuid();
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public string Slug { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
