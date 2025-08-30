using Blog4uSlf.Domain.Entities.Posts;

namespace Blog4uSlf.Application.Abstractions.Repositories;

public interface IPostRepository
{
  Task<Post?> GetByIdAsync(Guid id, CancellationToken ct);
  Task<IReadOnlyCollection<Post>> GetLatestAsync(int take, int skip, CancellationToken ct);
  Task<Post> AddAsync(PostCreate postCreate, CancellationToken ct);
  Task<Post?> UpdateByIdAsync(Guid id, PostUpdate postUpdate, CancellationToken ct);
  Task DeleteByIdAsync(Guid id, CancellationToken ct);
}
