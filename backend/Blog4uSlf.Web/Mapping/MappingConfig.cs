using Blog4uSlf.Domain.Models.Common.Page;
using Blog4uSlf.Domain.Models.Posts;
using Blog4uSlf.Infrastructure.Persistence.Models;
using Blog4uSlf.Web.Dtos.Posts;
using Mapster;

namespace Blog4uSlf.Web.Mapping;

public static class MappingConfig
{
  public static void Register()
  {
    MapFromApiToDomain();
    MapFromDomainToApi();
    MapFromDomainToDb();
    MapFromDbToDomain();
  }

  private static void MapFromApiToDomain()
  {
    TypeAdapterConfig<PostCreateDto, Post>
    .NewConfig()
    .ConstructUsing(src => new Post(src.Title, src.Content, src.Slug));

    TypeAdapterConfig<PostUpdateDto, Post>
    .NewConfig()
    .MapToTargetWith((src, dest) => dest.Update(src.Title, src.Content, src.Slug));

    TypeAdapterConfig<PostPaginationPageQueryParamsDto, PostPaginationPageQueryParams>
      .NewConfig();
  }

  private static void MapFromDomainToApi()
  {
    TypeAdapterConfig<Post, PostDto>.NewConfig();

    TypeAdapterConfig<Page<Post, IEnumerable<Post>>, Page<PostDto, IEnumerable<PostDto>>>.NewConfig();
  }

  private static void MapFromDomainToDb()
  {
    TypeAdapterConfig<Post, PostDb>.NewConfig();
  }

  private static void MapFromDbToDomain()
  {
    TypeAdapterConfig<PostDb, Post>.NewConfig();
  }

}
