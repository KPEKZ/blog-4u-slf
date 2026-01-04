using System.Globalization;
using Blog4uSlf.Domain.Enums.Common;
using Blog4uSlf.Domain.Enums.Posts;
using Blog4uSlf.Domain.Models.Common;
using Blog4uSlf.Infrastructure.Persistence.Models;

namespace Blog4uSlf.Infrastructure.Extensions.Posts;

public static partial class PostsQueryableExtensions
{
    extension<T>(IQueryable<T> source) where T : PostDb
    {
        public IQueryable<T> ApplyFiltering(IReadOnlyList<FilterParameter<PostFilterField>> filters)
        {
            if (filters.Count == 0)
            {
                return source;
            }

            return filters.Aggregate(source, ApplyFilter);
        }
    }

    private static IQueryable<T> ApplyFilter<T>(IQueryable<T> source, FilterParameter<PostFilterField> filter) where T : PostDb
    {
        return filter.Field switch
        {
            PostFilterField.Title => ApplyFilterForTitle(source, filter),
            PostFilterField.Content => ApplyFilterForContent(source, filter),
            PostFilterField.CreatedAt => ApplyFilterForCreationDate(source, filter),
            PostFilterField.UpdatedAt => ApplyFilterForUpdatingDate(source, filter),
            _ => throw new ArgumentOutOfRangeException(nameof(filter.Operator), filter.Operator, null)
        };
    }

    private static IQueryable<T> ApplyFilterForTitle<T>(IQueryable<T> source, FilterParameter<PostFilterField> filter) where T : PostDb
    {
        return filter.Operator switch
        {
            FilterOperator.Contains => source.Where(x => x.Title.ToLower().Contains(filter.Value.ToLower())),
            _ => throw new ArgumentOutOfRangeException(nameof(filter.Operator), filter.Operator, null)
        };
    }

    private static IQueryable<T> ApplyFilterForContent<T>(IQueryable<T> source, FilterParameter<PostFilterField> filter)
      where T : PostDb
    {
        return filter.Operator switch
        {
            FilterOperator.Contains => source.Where(x => x.Content.ToLower().Contains(filter.Value.ToLower())),
            _ => throw new ArgumentOutOfRangeException(nameof(filter.Operator), filter.Operator, null)
        };
    }

    private static IQueryable<T> ApplyFilterForCreationDate<T>(IQueryable<T> source, FilterParameter<PostFilterField> filter)
      where T : PostDb
    {
        var successParseDate = DateTimeOffset.TryParse(filter.Value, null, DateTimeStyles.RoundtripKind, out var dateTimeOffset);

        if (!successParseDate)
        {
            throw new InvalidCastException($"Cannot convert {filter.Value} to {typeof(T).Name}");
        }

        return filter.Operator switch
        {
            FilterOperator.Equals => source.Where(x => x.CreatedAt.Equals(dateTimeOffset)),
            FilterOperator.GreaterThan => source.Where(x => x.CreatedAt > dateTimeOffset),
            FilterOperator.LessThan => source.Where(x => x.CreatedAt < dateTimeOffset),
            FilterOperator.GreaterThanOrEqual => source.Where(x => x.CreatedAt >= dateTimeOffset),
            FilterOperator.LessThanOrEqual => source.Where(x => x.CreatedAt <= dateTimeOffset),
            _ => throw new ArgumentOutOfRangeException(nameof(filter.Operator), filter.Operator, null)
        };
    }

    private static IQueryable<T> ApplyFilterForUpdatingDate<T>(IQueryable<T> source, FilterParameter<PostFilterField> filter)
      where T : PostDb
    {
        var successParseDate = DateTimeOffset.TryParse(filter.Value, null, DateTimeStyles.RoundtripKind, out var dateTimeOffset);

        if (!successParseDate)
        {
            throw new InvalidCastException($"Cannot convert {filter.Value} to {typeof(T).Name}");
        }

        return filter.Operator switch
        {
            FilterOperator.Equals => source.Where(x => x.UpdatedAt.Equals(dateTimeOffset)),
            FilterOperator.GreaterThan => source.Where(x => x.UpdatedAt > dateTimeOffset),
            FilterOperator.LessThan => source.Where(x => x.UpdatedAt < dateTimeOffset),
            FilterOperator.GreaterThanOrEqual => source.Where(x => x.UpdatedAt >= dateTimeOffset),
            FilterOperator.LessThanOrEqual => source.Where(x => x.UpdatedAt <= dateTimeOffset),
            _ => throw new ArgumentOutOfRangeException(nameof(filter.Operator), filter.Operator, null)
        };
    }
}
