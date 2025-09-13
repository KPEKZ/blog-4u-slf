
using Blog4uSlf.Application.Dto.Posts;
using Blog4uSlf.Domain.Entities.Posts;
using Blog4uSlf.Infrastructure.Persistence.Models;
using Mapster;

namespace Blog4uSlf.Web.Mapping;

public static class MappingConfig
{
  public static void Register()
  {
    TypeAdapterConfig<PostCreateDto, Post>
    .NewConfig()
    .ConstructUsing(src => new Post(src.Title, src.Content, src.Slug));

    TypeAdapterConfig<PostUpdateDto, Post>
    .NewConfig()
    .MapToTargetWith((src, dest) => dest.Update(src.Title, src.Content, src.Slug));

    TypeAdapterConfig<Post, PostDto>.NewConfig();

    TypeAdapterConfig<Post, PostDb>.NewConfig();
    TypeAdapterConfig<PostDb, Post>.NewConfig();
  }
}
