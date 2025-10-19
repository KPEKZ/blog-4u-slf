using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Application.Exceptions.Posts;
using Blog4uSlf.Domain.Models.Posts;
using Microsoft.Extensions.Logging;

namespace Blog4uSlf.Application.Services;

public class PostService(IPostRepository postRepository, ILogger<PostService> logger) : IPostService
{
  private readonly IPostRepository _postRepository = postRepository;
  private readonly ILogger<PostService> _logger = logger;

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

  public async Task<Post> GetByIdAsync(Guid id, CancellationToken ct)
  {
    _logger.LogInformation("Fetching post with ID: {PostId}", id);

    var post = await _postRepository.GetByIdAsync(id, ct);

    if (post == null)
    {
      _logger.LogWarning("Post with ID: {PostId} not found", id);

      throw new PostNotFoundException(id);
    }

    return post;
  }

  public async Task<Post> GetByIdOrThrowNotFoundErrorAsync(Guid id, CancellationToken ct)
  {
    var post = await _postRepository.GetByIdAsync(id, ct);

    if (post == null)
    {
      _logger.LogWarning("Post with ID: {PostId} not found", id);

      throw new PostNotFoundException(id);
    }

    return post;
  }

  public async Task<IReadOnlyCollection<Post>> GetLatestsAsync(int take, int skip, CancellationToken ct)
  {
    _logger.LogInformation("Fetching latest posts with skip {Skip}, take {Take}", skip, take);

    return await _postRepository.GetLatestAsync(take, skip, ct);
  }

  public async Task<bool> SlugExistsAsync(string slug, CancellationToken ct)
  {
    return await _postRepository.SlugExistsAsync(slug, ct);
  }

  public async Task<Post> UpdateByIdAsync(Guid id, Post postUpdateDto, CancellationToken ct)
  {
    _logger.LogInformation("Updating post with ID: {PostId}", id);

    await GetByIdOrThrowNotFoundErrorAsync(id, ct);

    var updatedPost = await _postRepository.UpdateByIdAsync(id, postUpdateDto, ct);

    return updatedPost;
  }
}
