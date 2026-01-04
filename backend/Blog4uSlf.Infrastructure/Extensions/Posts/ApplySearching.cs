using Blog4uSlf.Infrastructure.Persistence.Models;

namespace Blog4uSlf.Infrastructure.Extensions.Posts;

public static partial class PostsQueryableExtensions
{
  extension<T>(IQueryable<T> source) where T : PostDb
  {
    public IQueryable<T> ApplySearching(string? search)
    {
      if (string.IsNullOrWhiteSpace(search))
      {
        return source;
      }

      return source.Where(p => p.Title.ToLower().Contains(search.ToLower()) || p.Content.ToLower().Contains(search.ToLower()));
    }
  }
}
