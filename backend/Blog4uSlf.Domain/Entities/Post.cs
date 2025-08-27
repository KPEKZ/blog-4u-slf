namespace Blob4uSlf.Domain;

public class Post
{
  public Guid Id { get; init; } = Guid.NewGuid();
  public string Title { get; set; } = String.Empty;
  public string Content { get; set; } = String.Empty;
  public string Slug { get; set; } = String.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  public Guid AuthorId { get; set; }
}
