using Blog4uSlf.Domain.Enums.Posts;
using Blog4uSlf.Domain.Interfaces.Common;
using Blog4uSlf.Domain.Models.Common;

namespace Blog4uSlf.Domain.Models.Posts;

public class PostPaginationPageQueryParams : IPaginatePageParams, ISearchable,
  ISortable<PostSortField>, IFilterable<PostFilterField>
{
  public int PageIndex { get; set; }
  public int PageSize { get; set; }
  public string? SearchTerm { get; set; }
  public List<SortParameter<PostSortField>> Sort { get; set; } = [];
  public List<FilterParameter<PostFilterField>> Filters { get; set; } = [];
}
