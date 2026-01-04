using Blog4uSlf.Web.Dtos.Posts;
using FluentValidation;

namespace Blog4uSlf.Web.Validation.Posts;

public class PostUpdateDtoValidator : AbstractValidator<PostUpdateDto>
{
  public PostUpdateDtoValidator()
  {
    RuleFor(x => x)
      .Must(x => new[] { x.Title, x.Content, x.Slug }.Any(y => !string.IsNullOrWhiteSpace(y)))
      .WithMessage("At least one of Title, Content or Slug must be provided.");

    RuleFor(x => x.Slug)
      .MaximumLength(200)
      .WithMessage("Slug must not exceed 200 characters.")
      .Matches("^[a-z0-9-]*$")
      .When(x => !string.IsNullOrWhiteSpace(x.Slug));
  }
}
