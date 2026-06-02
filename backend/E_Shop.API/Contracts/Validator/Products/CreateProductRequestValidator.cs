using E_Shop.API.Contracts.Products;
using FluentValidation;

namespace E_Shop.API.Contracts.Validator.Products;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
	public CreateProductRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(300);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(1000);

		RuleFor(x => x.Price)
			.NotEmpty()
			.GreaterThanOrEqualTo(1);

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
