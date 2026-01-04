namespace Blog4uSlf.Domain.Models.Common.Page;

/// <summary>
/// Represents a page of results.
/// </summary>
/// <typeparam name="T">The type of the items in the page.</typeparam>
/// <typeparam name="TCollection">The type of the collection of items in the page.</typeparam>
public sealed class Page<T, TCollection>(TCollection items, PageData pageData) where T : class where TCollection : IEnumerable<T>
{
  /// <summary>
  /// Gets the items.
  /// </summary>
  /// <value>The items.</value>
  public TCollection Items { get; set; } = items;

  /// <summary>
  /// Gets the page data.
  /// </summary>
  /// <value>The page data.</value>
  public PageData PageData { get; set; } = pageData;
}
