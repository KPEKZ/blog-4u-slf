using System.Collections.ObjectModel;
using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Domain.Entities.Posts;
using Blog4uSlf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace Blog4uSlf.Infrastructure.Repositories;

public class PostRepository(BlogDbContext context) : IPostRepository
{
  private readonly BlogDbContext _context = context;

  public async Task<Post> AddAsync(Post postCreate, CancellationToken ct)
  {
    var post = await _context.AddAsync(postCreate, ct);

    await _context.SaveChangesAsync(ct);

    return post.Entity;
  }

  public async Task DeleteByIdAsync(Guid id, CancellationToken ct)
  {
    var post = await _context.FindAsync<Post>(id, ct);

    if (post is not null)
    {
      _context.Remove(post);
    }

    await _context.SaveChangesAsync(ct);
  }

  public async Task<IReadOnlyCollection<Post>> GetLatestAsync(int take, int skip, CancellationToken ct)
  {
    var posts = await _context.Posts
      .AsNoTracking()
      .OrderByDescending(p => p.CreatedAt)
      .Skip(skip)
      .Take(take)
      .Select(postDb => postDb.Adapt<Post>())
      .ToListAsync(ct);

    return new ReadOnlyCollection<Post>(posts);
  }

  public async Task<Post?> GetByIdAsync(Guid id, CancellationToken ct)
  {
    var post = await _context.Posts
      .AsNoTracking()
      .FirstOrDefaultAsync(p => p.Id == id, ct);

    return post?.Adapt<Post>();
  }

  public async Task<Post?> UpdateByIdAsync(Guid id, Post postUpdate, CancellationToken ct)
  {
    var postDb = await _context.Posts.FindAsync(id, ct);

    if (postDb is null)
    {
      return null;
    }

    postDb.Title = postUpdate.Title;
    postDb.Content = postUpdate.Content;
    postDb.UpdatedAt = DateTime.UtcNow;
    postDb.Slug = postUpdate.Slug;

    await _context.SaveChangesAsync(ct);

    return postDb?.Adapt<Post>();
  }

  public Task<bool> SlugExistsAsync(string slug, CancellationToken ct)
  {
    return _context.Posts
      .AsNoTracking()
      .AnyAsync(p => p.Slug == slug, ct);
  }
}
