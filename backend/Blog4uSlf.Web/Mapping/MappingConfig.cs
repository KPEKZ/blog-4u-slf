
using Blog4uSlf.Application.Dto.Posts;
using Blog4uSlf.Domain.Models.Posts;
using Blog4uSlf.Infrastructure.Persistence.Models;
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
  }

  private static void MapFromDomainToApi()
  {
    TypeAdapterConfig<Post, PostDto>.NewConfig();
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
