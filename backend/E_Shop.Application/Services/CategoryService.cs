using CSharpFunctionalExtensions;
using E_Shop.Contracts.Contracts.Categories;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Application.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	public CategoryService(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<List<Category>> GetAllCategories()
	{
		return await _categoryRepository.GetAll();
	}

	public async Task<ActionResult<Guid>> CreateCategory(CreateCategoryRequest request)
	{
		var category = new Category
		{
			Id = Guid.NewGuid(),
			Name = request.Name,
			Description = request.Description,
		};

		var result = await _categoryRepository.Create(category);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("Ошибка при созаднии категории");
		}

		return new OkObjectResult(result);
	}

	public async Task<ActionResult<Guid>> UpdateInfo(CreateCategoryRequest request, Guid id)
	{
		var result = await _categoryRepository.Update(
			id,
			request.Name,
			request.Description);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("Ошибка при обновлении категории");
		}

		return new OkObjectResult(result);
	}

	public async Task<Result<Guid>> Delete(Guid id)
	{
		var result = await _categoryRepository.Delete(id);

		if (result == Guid.Empty)
			return Result.Failure<Guid>("Ошибка при удалении категории");

		return Result.Success<Guid>(result);
	}
}
