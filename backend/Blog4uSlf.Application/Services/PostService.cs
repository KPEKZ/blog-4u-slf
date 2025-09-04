using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Application.Exceptions;
using Blog4uSlf.Application.Exceptions.Posts;
using Blog4uSlf.Domain.Entities.Posts;

namespace Blog4uSlf.Application.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
  private readonly IPostRepository _postRepository = postRepository;

  public async Task<Post> CreateAsync(PostCreate postDto, CancellationToken ct)
  {
    try
    {
      var slugAlreadyExists = await _postRepository.SlugExistsAsync(postDto.Slug, ct);

      if (slugAlreadyExists)
      {
        throw new PostDuplicateSlugException(postDto.Slug);
      }

      var createdPost = await _postRepository.AddAsync(postDto, ct);

      return createdPost;
    }
    catch (PostDuplicateSlugException)
    {
      throw;
    }
    catch (AppException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task DeleteByIdAsync(Guid id, CancellationToken ct)
  {
    try
    {
      await GetByIdOrThrowNotFoundErrorAsync(id, ct);
      await _postRepository.DeleteByIdAsync(id, ct);
    }
    catch (PostNotFoundException)
    {
      throw;
    }
    catch (AppException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<Post> GetByIdAsync(Guid id, CancellationToken ct)
  {
    try
    {
      var post = await _postRepository.GetByIdAsync(id, ct);

      return post ?? throw new PostNotFoundException(id);
    }
    catch (PostNotFoundException)
    {
      throw;
    }
    catch (AppException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<Post> GetByIdOrThrowNotFoundErrorAsync(Guid id, CancellationToken ct)
  {
    var post = await _postRepository.GetByIdAsync(id, ct);

    return post ?? throw new PostNotFoundException(id);
  }

  public async Task<IReadOnlyCollection<Post>> GetLatestsAsync(int take, int skip, CancellationToken ct)
  {
    try
    {
      return await _postRepository.GetLatestAsync(take, skip, ct);
    }
    catch (AppException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<bool> SlugExistsAsync(string slug, CancellationToken ct)
  {
    return await _postRepository.SlugExistsAsync(slug, ct);
  }

  public async Task<Post> UpdateByIdAsync(Guid id, PostUpdate postDto, CancellationToken ct)
  {
    try
    {
      await GetByIdOrThrowNotFoundErrorAsync(id, ct);
      var updatedPost = await _postRepository.UpdateByIdAsync(id, postDto, ct);

      return updatedPost;
    }
    catch (PostNotFoundException)
    {
      throw;
    }
    catch (AppException)
    {
      throw;
    }
    catch (Exception)
    {
      throw;
    }
  }
}
