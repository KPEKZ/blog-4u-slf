
using Blog4uSlf.Application.Dto.Posts;
using Blog4uSlf.Domain.Entities.Posts;
using Mapster;

namespace Blog4uSlf.Web.Mapping;

public static class MappingConfig
{
  public static void Register()
  {
    TypeAdapterConfig<Post, PostDto>.NewConfig();
    TypeAdapterConfig<PostCreateDto, PostCreate>.NewConfig();
    TypeAdapterConfig<PostUpdateDto, PostUpdate>.NewConfig();
  }
}
