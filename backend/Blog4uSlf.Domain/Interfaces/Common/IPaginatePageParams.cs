namespace Blog4uSlf.Domain.Interfaces.Common;

/// <summary>
/// Represents a pagination page parameters for a query.
/// </summary>
public interface IPaginatePageParams
{
  /// <summary>
  /// Gets or sets the page index.
  /// </summary>
  /// <value>The page index.</value>
  int PageIndex { get; set; }

  /// <summary>
  /// Gets or sets the page size.
  /// </summary>
  /// <value>The page size.</value>
  int PageSize { get; set; }
}
