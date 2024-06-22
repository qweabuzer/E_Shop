using E_Shop.API.Contracts.Categories;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers
{
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
                .Select(c => new CategoryResponse(
                    c.Id,
                    c.Name,
                    c.Description));

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CategoryRequest request)
        {
            var category = Category.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description);

            if (category.IsFailure)
            {
                _logger.LogError(category.Error);
                return BadRequest(category.Error);
            }

            var categoryId = await _categoryService.CreateCategory(category.Value);

            if (categoryId.IsFailure)
            {
                _logger.LogError(categoryId.Error);
                return BadRequest(categoryId.Error);
            }

            return Ok(categoryId.Value);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Guid>> UpdateInfo(Guid id, [FromBody] CategoryRequest request)
        {
            var categoryId = await _categoryService.UpdateInfo(
                id,
                request.Name,
                request.Description);

            if (categoryId.IsFailure)
            {
                _logger.LogError(categoryId.Error);
                return BadRequest(categoryId.Error);
            }

            return Ok(categoryId.Value);
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
}
