using Blog4uSlf.Web.Validation.Posts;
using FluentValidation;

namespace Blog4uSlf.Web.Extensions;

/// <summary>
/// Provides extension methods for registering FluentValidation validators in the service collection.
/// </summary>
public static class ValidationExtensions
{
  public static IServiceCollection AddFluentValidation(this IServiceCollection services)
  {
    services.AddValidatorsFromAssemblyContaining<PostCreateDtoValidator>();
    services.AddValidatorsFromAssemblyContaining<PostUpdateDtoValidator>();
    services.AddValidatorsFromAssemblyContaining<PostPageQueryValidator>();

    return services;
  }
}
