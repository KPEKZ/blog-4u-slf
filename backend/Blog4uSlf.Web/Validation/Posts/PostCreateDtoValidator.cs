using Blog4uSlf.Web.Dtos.Posts;
using FluentValidation;

namespace Blog4uSlf.Web.Validation.Posts;

public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
  public PostCreateDtoValidator()
  {
    RuleFor(x => x.Title)
      .NotEmpty()
      .WithMessage("Title is required.");

    RuleFor(x => x.Content)
      .NotEmpty()
      .WithMessage("Content is required.");

    RuleFor(x => x.Slug)
      .MaximumLength(200)
      .WithMessage("Slug must not exceed 200 characters.")
      .Matches("^[a-z0-9-]*$")
      .When(x => !string.IsNullOrWhiteSpace(x.Slug));
  }
}
