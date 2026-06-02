using E_Shop.API.Contracts.Users;
using FluentValidation;

namespace E_Shop.API.Contracts.Validator.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUsersRequest>
{
	public UpdateUserRequestValidator()
	{
		ClassLevelCascadeMode = CascadeMode.Stop;

		RuleFor(x => x.Name)
			.NotEmpty()
			.MaximumLength(20)
			.When(x => x.Name is not null);

		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress()
			.MaximumLength(40)
			.When(x => x.Email is not null);

		RuleFor(x => x.Login)
			.NotEmpty()
			.Matches("^[a-zA-Z0-9]+$")
			.MinimumLength(3)
			.MaximumLength(40)
			.When(x => x.Login is not null);

		RuleFor(x => x.Password)
			.NotEmpty()
			.MinimumLength(6)
			.MaximumLength(40)
			.When(x => x.Password is not null);

		RuleFor(x => x.ProfileImage)
			.Matches(@"^https?://.*\.(jpg|jpeg|png|gif|webp)$")
			.WithMessage("ссылка должна вести на изображение jpg, jpeg, png, gif, webp")
			.When(x => !string.IsNullOrEmpty(x.ProfileImage));
	}
}
