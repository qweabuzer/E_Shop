using E_Shop.API.Contracts.Categories;
using FluentValidation;

namespace E_Shop.API.Contracts.Validator.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CategoryRequest>
{
	public CreateCategoryRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(25);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(250);
	}
}
