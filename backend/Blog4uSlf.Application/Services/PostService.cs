using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Application.Exceptions.Posts;
using Blog4uSlf.Domain.Models.Common.Page;
using Blog4uSlf.Domain.Models.Posts;
using Microsoft.Extensions.Logging;

namespace Blog4uSlf.Application.Services;

public class PostService(IPostRepository postRepository, ILogger<PostService> logger) : IPostService
{
  private readonly IPostRepository _postRepository = postRepository;
  private readonly ILogger<PostService> _logger = logger;

  public async Task<Post> GetByIdOrThrowNotFoundErrorAsync(Guid id, CancellationToken ct)
  {
    _logger.LogInformation("Getting post with ID: {PostId}", id);

    var post = await _postRepository.GetByIdAsync(id, ct);

    if (post is not null) return post;

    _logger.LogWarning("Post with ID: {PostId} not found", id);

    throw new PostNotFoundException(id);
  }

  public async Task<Page<Post, IReadOnlyList<Post>>> GetPageAsync(PostPaginationPageQueryParams pageParams, CancellationToken ct)
  {
    _logger.LogInformation("Getting paginated posts with params: pageIndex = {PageIndex}, pageSize = {PageSize}",
      pageParams.PageIndex,
      pageParams.PageSize);

    return await _postRepository.GetPostsPageAsync(pageParams, ct);
  }

  public async Task<Post> CreateAsync(Post postCreateDto, CancellationToken ct)
  {
    _logger.LogInformation("Creating new post with Title: {Title}", postCreateDto.Title);

    var slugAlreadyExists = await _postRepository.SlugExistsAsync(postCreateDto.Slug, ct);

    if (slugAlreadyExists)
    {
      throw new PostDuplicateSlugException(postCreateDto.Slug);
    }

    var createdPost = await _postRepository.AddAsync(postCreateDto, ct);

    return createdPost;
  }

  public async Task DeleteByIdAsync(Guid id, CancellationToken ct)
  {
    _logger.LogInformation("Deleting post with ID: {PostId}", id);

    await GetByIdOrThrowNotFoundErrorAsync(id, ct);
    await _postRepository.DeleteByIdAsync(id, ct);
  }

  public async Task<bool> SlugExistsAsync(string slug, CancellationToken ct)
  {
    return await _postRepository.SlugExistsAsync(slug, ct);
  }

  public async Task<Post> UpdateByIdAsync(Guid id, Post postUpdateDto, CancellationToken ct)
  {
    _logger.LogInformation("Updating post with ID: {PostId}", id);

    var updatedPost = await _postRepository.UpdateByIdAsync(id, postUpdateDto, ct);

    return updatedPost ?? throw new PostNotFoundException(id);
  }
}
