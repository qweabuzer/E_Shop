using E_Shop.Contracts.Contracts.Users;
using FluentValidation;

namespace E_Shop.API.Validator.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUsersRequest>
{
	public CreateUserRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(20);

		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress()
			.MaximumLength(40);

		RuleFor(x => x.Login)
			.NotEmpty()
			.Matches("^[a-zA-Z0-9]+$")
			.MinimumLength(3)
			.MaximumLength(40);

		RuleFor(x => x.Password)
			.NotEmpty()
			.MinimumLength(6)
			.MaximumLength(40);

		RuleFor(x => x.ProfileImage)
			.Matches(@"^https?://.*\.(jpg|jpeg|png|gif|webp)$")
			.WithMessage("ссылка должна вести на изображение jpg, jpeg, png, gif, webp")
			.When(x => !string.IsNullOrEmpty(x.ProfileImage));
	}
}
