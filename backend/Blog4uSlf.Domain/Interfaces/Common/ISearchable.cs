namespace Blog4uSlf.Domain.Interfaces.Common;

/// <summary>
/// Represents a query parameter that supports searching.
/// </summary>
public interface ISearchable
{
  /// <summary>
  /// Gets or sets the search term.
  /// </summary>
  string? SearchTerm { get; set; }
}
