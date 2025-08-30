using System.Collections.ObjectModel;
using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Domain.Entities.Posts;
using Blog4uSlf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Blog4uSlf.Infrastructure.Repositories;

public class PostRepository(BlogDbContext context) : IPostRepository
{
  private readonly BlogDbContext _context = context;

  public async Task<Post> AddAsync(PostCreate postCreate, CancellationToken ct)
  {
    var post = new Post
    {
      Title = postCreate.Title,
      Content = postCreate.Content,
      Slug = postCreate.Slug
    };

    await _context.AddAsync(post, ct);
    await _context.SaveChangesAsync(ct);

    return post;
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
      .ToListAsync(ct);

    return new ReadOnlyCollection<Post>(posts);
  }

  public async Task<Post?> GetByIdAsync(Guid id, CancellationToken ct)
  {
    return await _context.Posts
      .AsNoTracking()
      .FirstOrDefaultAsync(p => p.Id == id, ct);
  }

  public async Task<Post?> UpdateByIdAsync(Guid id, PostUpdate postUpdate, CancellationToken ct)
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

    return postDb;
  }
}
