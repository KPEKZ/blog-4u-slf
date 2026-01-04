namespace Blog4uSlf.Domain.Enums.Common;

/// <summary>
/// Defines comparison operators used when constructing filters for queries or in-memory collections.
/// </summary>
/// <remarks>
/// Use these operators to express equality, relational comparisons, substring checks, or set membership
/// when building filter expressions. How each operator maps to database or LINQ semantics may depend on
/// the underlying provider and the types being compared.
/// </remarks>
public enum FilterOperator : byte
{
  Equals = 0,
  NotEquals = 1,
  Contains = 2,
  GreaterThan = 3,
  LessThan = 4,
  GreaterThanOrEqual = 5,
  LessThanOrEqual = 6,
  In = 7
}
