using Blog4uSlf.Domain.Enums.Common;

namespace Blog4uSlf.Domain.Models.Common;

/// <summary>
/// Represents a sort parameter for a query.
/// </summary>
/// <typeparam name="TField">The type of the field.</typeparam>
public readonly record struct SortParameter<TField>(
  TField Field,
  OrderBy OrderBy,
  int Priority = 0
) where TField : Enum;
