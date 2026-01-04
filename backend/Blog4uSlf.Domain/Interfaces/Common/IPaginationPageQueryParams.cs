using Blog4uSlf.Domain.Enums.Common;

namespace Blog4uSlf.Domain.Interfaces.Common;

public interface IPaginationPageQueryParams<TField> :
    IPaginatePageParams, ISearchable, ISortable<TField> where TField : Enum;
