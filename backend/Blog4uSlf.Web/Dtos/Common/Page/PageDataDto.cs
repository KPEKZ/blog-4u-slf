namespace Blog4uSlf.Web.Dtos.Common.Page;

/// <summary>
/// Represents a page data of results.
/// </summary>
/// <param name="PageIndex">The index of the page.</param>
/// <param name="TotalPages">The total number of pages.</param>
/// <param name="TotalCount">The total number of items.</param>
/// <param name="HasPreviousPage">Indicates whether there is a previous page.</param>
/// <param name="HasNextPage">Indicates whether there is a next page.</param>
public sealed record PageDataDto(int PageIndex,
  int TotalPages,
  int TotalCount,
  bool HasPreviousPage,
  bool HasNextPage);
