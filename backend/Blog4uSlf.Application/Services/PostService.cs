using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Application.Abstractions.Services;
using Blog4uSlf.Domain.Entities.Posts;

namespace Blog4uSlf.Application.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
  private readonly IPostRepository _postRepository = postRepository;

  public async Task<Post> CreateAsync(PostCreate postDto, CancellationToken ct)
  {
    try
    {

      var createdPost = await _postRepository.AddAsync(postDto, ct);

      return createdPost;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public async Task DeleteByIdAsync(Guid id, CancellationToken ct)
  {
    try
    {
      await _postRepository.DeleteByIdAsync(id, ct);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public async Task<Post> GetByIdAsync(Guid id, CancellationToken ct)
  {
    try
    {
      var post = await _postRepository.GetByIdAsync(id, ct);

      return post is not null ? post : throw new Exception("Post not found");
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public async Task<IReadOnlyCollection<Post>> GetLatestsAsync(int take, int skip, CancellationToken ct)
  {
    try
    {
      return await _postRepository.GetLatestAsync(take, skip, ct);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public async Task<Post> UpdateByIdAsync(Guid id, PostUpdate postDto, CancellationToken ct)
  {
    try
    {
      var post = await _postRepository.GetByIdAsync(id, ct) ?? throw new Exception("Post not found");

      await _postRepository.UpdateByIdAsync(id, postDto, ct);

      return post;
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
