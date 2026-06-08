using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using E_Shop.API.Extensions;

namespace E_Shop.API.Filters;

public class FluentValidationFilter : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		foreach (var arg in context.ActionArguments.Values)
		{
			if (arg == null)
			{
				continue;
			}

			var validator = context.HttpContext.RequestServices.GetValidator(arg);

			if (validator == null)
			{
				continue;
			}

			var validationObject = new ValidationContext<object>(arg);
			var validationResult = await validator.ValidateAsync(validationObject);

			if (!validationResult.IsValid)
			{
				var error = validationResult.Errors.First();
				context.Result = new BadRequestObjectResult(error.ErrorResponse());

				return;
			}
		}

		await next();
	}
}
