using Blog4uSlf.Domain.Models.Common;

namespace Blog4uSlf.Domain.Interfaces.Common;

public interface IFilterable<TField> where TField : Enum
{
  List<FilterParameter<TField>> Filters { get; set; }
}
