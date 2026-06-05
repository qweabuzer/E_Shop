using E_Shop.Contracts.Contracts.Categories;
using FluentValidation;

namespace E_Shop.API.Validator.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
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
