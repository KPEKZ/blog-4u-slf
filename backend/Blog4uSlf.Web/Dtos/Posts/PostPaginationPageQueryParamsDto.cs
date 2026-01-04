using Blog4uSlf.Domain.Enums.Posts;
using Blog4uSlf.Domain.Interfaces.Common;
using Blog4uSlf.Domain.Models.Common;
using Blog4uSlf.Web.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blog4uSlf.Web.Dtos.Posts;

public class PostPaginationPageQueryParamsDto : IPaginatePageParams, ISearchable,
  ISortable<PostSortField>, IFilterable<PostFilterField>
{
  public required int PageIndex { get; set; }
  public required int PageSize { get; set; }
  public string? SearchTerm { get; set; }

  [ModelBinder(BinderType = typeof(JsonQueryModelBinder))]
  [SwaggerSchema(Description = "JSON array of SortParameter objects")]
  public List<SortParameter<PostSortField>> Sort { get; set; } = [];

  [ModelBinder(BinderType = typeof(JsonQueryModelBinder))]
  [SwaggerSchema(Description = "JSON array of SortParameter objects")]
  public List<FilterParameter<PostFilterField>> Filters { get; set; } = [];
}
