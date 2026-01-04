using Blog4uSlf.Domain.Models.Common;

namespace Blog4uSlf.Domain.Interfaces.Common;

/// <summary>
/// Represents a query with sorting parameters.
/// </summary>
/// <typeparam name="TField">The type of the field.</typeparam>
public interface ISortable<TField> where TField : Enum
{
  /// <summary>
  /// Gets the sort parameters for a query.
  /// </summary>
  /// <value>
  /// The sort parameters, where the key is the field and the value is the sort order.
  /// </value>
  /// <returns>
  /// The sort parameters.
  /// </returns>
  public List<SortParameter<TField>> Sort { get; set; }
}
