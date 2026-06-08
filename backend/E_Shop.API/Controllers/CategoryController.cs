using E_Shop.Contracts.Contracts.Categories;
using E_Shop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
	private readonly ICategoryService _categoryService;
	private readonly ILogger<CategoryController> _logger;

	public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
	{
		_categoryService = categoryService;
		_logger = logger;
	}

	[HttpGet("GetAll")]
	public async Task<ActionResult<List<CategoryResponse>>> GetAll()
	{
		var products = await _categoryService.GetAllCategories();

		var response = products
			.Select(c => new CategoryResponse
			{
				Id = c.Id,
				Name = c.Name,
				Description = c.Description
			});

		return Ok(response);
	}

	[HttpPost("Create")]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryRequest request)
	{
		return await _categoryService.CreateCategory(request);
	}

	[HttpPatch("Update")]
	public async Task<ActionResult<Guid>> UpdateInfo(Guid id, [FromBody] CreateCategoryRequest request)
	{
		return await _categoryService.UpdateInfo(request, id);
	}

	[HttpDelete("Delete")]
	public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
	{
		var categoryId = await _categoryService.Delete(id);

		if (categoryId.IsFailure)
		{
			_logger.LogError(categoryId.Error);
			return BadRequest(categoryId.Error);
		}

		return Ok(categoryId.Value);
	}
}
