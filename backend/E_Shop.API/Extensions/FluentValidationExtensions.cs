using FluentValidation.Results;

namespace E_Shop.API.Extensions;

public static class FluentValidationExtensions
{
	public static List<object> ErrorResponse(this IList<ValidationFailure> error)
	{
		return error.Select(e => new
		{
			field = e.PropertyName,
			message = e.ErrorMessage

		}).ToList<object>();
	}
}
