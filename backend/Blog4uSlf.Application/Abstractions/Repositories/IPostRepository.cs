using Blog4uSlf.Domain.Models.Posts;

namespace Blog4uSlf.Application.Abstractions.Repositories;

/// <summary>
/// Defines methods for managing <see cref="Post"/> entities in the repository.
/// </summary>
public interface IPostRepository
{
  /// <summary>
  /// Retrieves a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The post if found; otherwise, <c>null</c>.</returns>
  Task<Post?> GetByIdAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Retrieves the latest posts with pagination.
  /// </summary>
  /// <param name="take">The number of posts to take.</param>
  /// <param name="skip">The number of posts to skip.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>A read-only collection of the latest posts.</returns>
  Task<IReadOnlyCollection<Post>> GetLatestAsync(int take, int skip, CancellationToken ct);

  /// <summary>
  /// Adds a new post to the repository.
  /// </summary>
  /// <param name="postCreate">The data for the post to create.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The created post.</returns>
  Task<Post> AddAsync(Post postCreate, CancellationToken ct);

  /// <summary>
  /// Updates an existing post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post to update.</param>
  /// <param name="postUpdate">The updated post data.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The updated post if found; otherwise, <c>null</c>.</returns>
  Task<Post?> UpdateByIdAsync(Guid id, Post postUpdate, CancellationToken ct);

  /// <summary>
  /// Deletes a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post to delete.</param>
  /// <param name="ct">A cancellation token.</param>
  Task DeleteByIdAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Checks if a post with the specified slug exists.
  /// </summary>
  /// <param name="slug">The slug to check for existence.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns><c>true</c> if the slug exists; otherwise, <c>false</c>.</returns>
  Task<bool> SlugExistsAsync(string slug, CancellationToken ct);
}
