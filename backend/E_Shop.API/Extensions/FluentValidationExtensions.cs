using FluentValidation;
using FluentValidation.Results;

namespace E_Shop.API.Extensions;

public static class FluentValidationExtensions
{
	public static object ErrorResponse(this ValidationFailure error)
	{
		return new
		{
			field = error.PropertyName,
			message = error.ErrorMessage
		};
	}

	public static IValidator? GetValidator(this IServiceProvider services, object arg)
	{
		var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
		return services.GetService(validatorType) as IValidator;
	}
}
