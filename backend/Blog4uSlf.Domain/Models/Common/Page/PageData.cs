namespace Blog4uSlf.Domain.Models.Common.Page;

/// <summary>
/// Represents a page data of results.
/// </summary>
/// <param name="pageIndex">The index of the page.</param>
/// <param name="totalPages">The total number of pages.</param>
/// <param name="totalCount">The total number of items.</param>
public sealed class PageData(int pageIndex, int totalPages, int totalCount)
{
  /// <summary>
  /// Gets or sets the index of the page.
  /// </summary>
  public int PageIndex { get; set; } = pageIndex;

  /// <summary>
  /// Gets or sets the total number of pages.
  /// </summary>
  public int TotalPages { get; set; } = totalPages;

  /// <summary>
  /// Gets or sets the total number of items.
  /// </summary>
  public int TotalCount { get; set; } = totalCount;

  /// <summary>
  /// Indicates whether there is a previous page.
  /// </summary>
  public bool HasPreviousPage => PageIndex > 1;

  /// <summary>
  /// Indicates whether there is a next page.
  /// </summary>
  public bool HasNextPage => PageIndex < TotalPages;
}
