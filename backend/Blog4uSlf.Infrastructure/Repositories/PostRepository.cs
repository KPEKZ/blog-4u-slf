using Blog4uSlf.Application.Abstractions.Repositories;
using Blog4uSlf.Domain.Models.Posts;
using Blog4uSlf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Blog4uSlf.Infrastructure.Persistence.Models;
using Blog4uSlf.Domain.Models.Common.Page;
using Blog4uSlf.Infrastructure.Extensions.Posts;

namespace Blog4uSlf.Infrastructure.Repositories;

public class PostRepository(BlogDbContext context) : IPostRepository
{
  private readonly BlogDbContext _context = context;

  public async Task<Post?> GetByIdAsync(Guid id, CancellationToken ct)
  {
    var post = await _context.Posts
      .AsNoTracking()
      .FirstOrDefaultAsync(p => p.Id == id, ct);

    return post?.Adapt<Post>();
  }

  public async Task<Page<Post, IReadOnlyList<Post>>> GetPostsPageAsync(PostPaginationPageQueryParams pageParams, CancellationToken ct)
  {
    var posts = _context.Posts
      .AsQueryable()
      .AsNoTracking()
      .ApplySearching(pageParams.SearchTerm)
      .ApplySorting(pageParams.Sort)
      .ApplyFiltering(pageParams.Filters);

    var totalPostsCount = await _context.Posts.CountAsync(ct);

    var paginatedPosts = await posts
      .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
      .Take(pageParams.PageSize)
      .Select(postDb => postDb.Adapt<Post>())
      .ToListAsync(ct);

    var totalPages = (int)Math.Ceiling((double)totalPostsCount / pageParams.PageSize);

    var pageData = new PageData(
      pageIndex: pageParams.PageIndex,
      totalPages,
      totalCount: totalPostsCount);

    var page = new Page<Post, IReadOnlyList<Post>>(
      items: paginatedPosts,
      pageData);

    return page;
  }

  public async Task<Post> AddAsync(Post postCreate, CancellationToken ct)
  {
    var post = await _context.Posts.AddAsync(postCreate.Adapt<PostDb>(), ct);

    await _context.SaveChangesAsync(ct);

    return post.Entity.Adapt<Post>();
  }

  public async Task DeleteByIdAsync(Guid id, CancellationToken ct)
  {
    var post = await _context.Posts.FindAsync(id, ct);

    if (post is not null)
    {
      _context.Remove(post);
    }

    await _context.SaveChangesAsync(ct);
  }

  public async Task<Post?> UpdateByIdAsync(Guid id, Post postUpdate, CancellationToken ct)
  {
    var postDb = await _context.Posts
      .AsNoTracking()
      .FirstOrDefaultAsync(p => p.Id == id, ct);

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
