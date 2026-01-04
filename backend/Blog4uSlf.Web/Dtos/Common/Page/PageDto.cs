namespace Blog4uSlf.Web.Dtos.Common.Page;

/// <summary>
/// Represents a page data of results.
/// </summary>
/// <typeparam name="T">The type of the items.</typeparam>
/// <param name="Items">The items.</param>
/// <param name="PageData">The page data.</param>
public sealed record PageDto<T>(IEnumerable<T> Items, PageDataDto PageData) where T : class;
