using Blog4uSlf.Domain.Enums.Common;

namespace Blog4uSlf.Domain.Models.Common;


public readonly record struct FilterParameter<TField>(
  TField Field,
  FilterOperator Operator,
  string Value
) where TField : Enum;
