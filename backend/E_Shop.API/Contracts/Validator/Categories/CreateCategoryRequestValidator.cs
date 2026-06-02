using E_Shop.API.Contracts.Categories;
using FluentValidation;

namespace E_Shop.API.Contracts.Validator.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
	public CreateCategoryRequestValidator()
	{
		ClassLevelCascadeMode = CascadeMode.Stop;

		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(25);

		RuleFor(x => x.Description)
			.NotEmpty()
			.MaximumLength(250);
	}
}
