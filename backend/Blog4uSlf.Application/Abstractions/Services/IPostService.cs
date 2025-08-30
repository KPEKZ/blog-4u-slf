
using Blog4uSlf.Domain.Entities.Posts;

namespace Blog4uSlf.Application.Abstractions.Services;

public interface IPostService
{
  Task<Post> CreateAsync(PostCreate postDto, CancellationToken ct);
  Task<Post> GetByIdAsync(Guid id, CancellationToken ct);
  Task<IReadOnlyCollection<Post>> GetLatestsAsync(int take, int skip, CancellationToken ct);
  Task<Post> UpdateByIdAsync(Guid id, PostUpdate postDto, CancellationToken ct);
  Task DeleteByIdAsync(Guid id, CancellationToken ct);
}
