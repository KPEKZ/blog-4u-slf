using System.Linq.Expressions;
using Blog4uSlf.Domain.Enums.Common;
using Blog4uSlf.Domain.Enums.Posts;
using Blog4uSlf.Domain.Models.Common;
using Blog4uSlf.Infrastructure.Persistence.Models;

namespace Blog4uSlf.Infrastructure.Extensions.Posts;

public static partial class PostsQueryableExtensions
{
  extension<T>(IQueryable<T> source) where T : PostDb
  {
    public IOrderedQueryable<T> ApplySorting(IReadOnlyList<SortParameter<PostSortField>> sortParameters)
    {
      if (sortParameters.Count == 0)
      {
        return source.OrderByDescending(x => x.CreatedAt);
      }

      var sortedByPriorityParams = sortParameters.OrderBy(field => field.Priority);

      IOrderedQueryable<T>? ordered = null;

      foreach (var param in sortedByPriorityParams)
      {
        var keySelector = GetSortExpression<T>(param.Field);

        ordered = ordered is null
          ? ApplyOrder(source, keySelector, param.OrderBy)
          : ApplyThenOrder(ordered, keySelector, param.OrderBy);
      }

      return ordered ?? source.OrderByDescending(x => x.CreatedAt);
    }
  }

  private static Expression<Func<T, object>> GetSortExpression<T>(PostSortField field)
    where T : PostDb
  {
    return field switch
    {
      PostSortField.Title => x => x.Title,
      PostSortField.CreatedAt => x => x.CreatedAt,
      PostSortField.UpdatedAt => x => x.UpdatedAt,
      _ => throw new ArgumentOutOfRangeException(nameof(field))
    };
  }

  private static IOrderedQueryable<T> ApplyOrder<T>(
    IQueryable<T> source,
    Expression<Func<T, object>> key,
    OrderBy order)
  {
    return order == OrderBy.Asc
      ? source.OrderBy(key)
      : source.OrderByDescending(key);
  }

  private static IOrderedQueryable<T> ApplyThenOrder<T>(
    IOrderedQueryable<T> source,
    Expression<Func<T, object>> key,
    OrderBy order)
  {
    return order == OrderBy.Asc
      ? source.ThenBy(key)
      : source.ThenByDescending(key);
  }
}
