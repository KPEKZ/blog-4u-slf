using Blog4uSlf.Domain.Models.Common.Page;
using Blog4uSlf.Domain.Models.Posts;

namespace Blog4uSlf.Application.Abstractions.Services;

/// <summary>
/// Defines operations for managing blog posts.
/// </summary>
public interface IPostService
{
  /// <summary>
  /// Gets a post by its unique identifier or throws a not found error if it does not exist.
  /// </summary>
  /// <param name="id">The unique identifier of the post.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The <see cref="Post"/>.</returns>
  /// <exception cref="NotFoundException">Thrown if the post is not found.</exception>
  Task<Post> GetByIdOrThrowNotFoundErrorAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Gets the paginated posts.
  /// </summary>
  /// <param name="pageParams">The pagination page query params</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>A read-only collection of the posts <see cref="Post"/> objects.</returns>
  Task<Page<Post, IReadOnlyList<Post>>> GetPageAsync(PostPaginationPageQueryParams pageParams, CancellationToken ct);

  /// <summary>
  /// Creates a new post.
  /// </summary>
  /// <param name="postCreateDto">The data for the post to create.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The created <see cref="Post"/>.</returns>
  Task<Post> CreateAsync(Post postCreateDto, CancellationToken ct);

  /// <summary>
  /// Updates a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post.</param>
  /// <param name="postUpdateDto">The updated post data.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>The updated <see cref="Post"/>.</returns>
  Task<Post> UpdateByIdAsync(Guid id, Post postUpdateDto, CancellationToken ct);

  /// <summary>
  /// Deletes a post by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the post.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>A task representing the asynchronous operation.</returns>
  Task DeleteByIdAsync(Guid id, CancellationToken ct);

  /// <summary>
  /// Checks if a post with the specified slug exists.
  /// </summary>
  /// <param name="slug">The slug to check for existence.</param>
  /// <param name="ct">A cancellation token.</param>
  /// <returns>True if the slug exists; otherwise, false.</returns>
  Task<bool> SlugExistsAsync(string slug, CancellationToken ct);
}
