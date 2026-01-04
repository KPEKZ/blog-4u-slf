using Blog4uSlf.Domain.Models.Common.Page;
using Blog4uSlf.Domain.Models.Posts;

namespace Blog4uSlf.Application.Abstractions.Repositories;

/// <summary>
/// Defines methods for managing <see cref="Post"/> entities in the repository.
/// </summary>
public interface IPostRepository
{
  public Task<Page<Post, IReadOnlyList<Post>>> GetPostsPageAsync(PostPaginationPageQueryParams postPageQueryParams, CancellationToken ct);

  /// <summary>
  /// Retrieves a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The post if found; otherwise, <c>null</c>.</returns>
  public Task<Post?> GetByIdAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Adds a new post to the repository.
  /// </summary>
  /// <param name="postCreate">The data for the post to create.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The created post.</returns>
  public Task<Post> AddAsync(Post postCreate, CancellationToken ct);

  /// <summary>
  /// Updates an existing post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post to update.</param>
  /// <param name="postUpdate">The updated post data.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The updated post if found; otherwise, <c>null</c>.</returns>
  public Task<Post?> UpdateByIdAsync(Guid id, Post postUpdate, CancellationToken ct);

  /// <summary>
  /// Deletes a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post to delete.</param>
  /// <param name="ct">A cancellation token.</param>
  public Task DeleteByIdAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Checks if a post with the specified slug exists.
  /// </summary>
  /// <param name="slug">The slug to check for existence.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns><c>true</c> if the slug exists; otherwise, <c>false</c>.</returns>
  public Task<bool> SlugExistsAsync(string slug, CancellationToken ct);
}
