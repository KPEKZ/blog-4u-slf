using Blog4uSlf.Web.Dtos.Posts;
using FluentValidation;

namespace Blog4uSlf.Web.Validation.Posts;

public class PostPageQueryValidator: AbstractValidator<PostPaginationPageQueryParamsDto>
{
  public PostPageQueryValidator()
  {
    RuleFor(f => f.PageIndex)
      .GreaterThanOrEqualTo(1)
      .WithMessage("PageIndex must be greater than or equal to 1. PageIndex: {f.PageIndex}");

    RuleFor(f => f.PageSize)
      .GreaterThanOrEqualTo(1)
      .WithMessage("PageSize must be greater than or equal to 1. PageSize: {f.PageSize}");
  }
}
