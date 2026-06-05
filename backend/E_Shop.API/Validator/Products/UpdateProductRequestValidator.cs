using E_Shop.Contracts.Contracts.Products;
using FluentValidation;

namespace E_Shop.API.Validator.Products;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
	public UpdateProductRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(300)
			 .When(x => x.Name is not null);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(1000)
			 .When(x => x.Description is not null);

		RuleFor(x => x.Price)
			.GreaterThanOrEqualTo(1)
			.When(x => x.Price.HasValue);

		RuleFor(x => x.Image)
			.NotEmpty()
			.Matches(@"^https?://.*\.(jpg|jpeg|png|gif|webp)$")
			.WithMessage("ссылка должна вести на изображение jpg, jpeg, png, gif, webp")
			.When(x => !string.IsNullOrEmpty(x.Image));

		RuleFor(x => x.CategoryId)
			.NotEqual(Guid.Empty)
			.When(x => x.CategoryId.HasValue);
	}
}
