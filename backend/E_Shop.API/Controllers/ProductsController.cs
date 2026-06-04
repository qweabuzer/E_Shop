using E_Shop.Contracts.Contracts.Products;
using E_Shop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductsService _productsService;
	private readonly ILogger<ProductsController> _logger;
	public ProductsController(IProductsService productsService, ILogger<ProductsController> logger)
	{
		_productsService = productsService;
		_logger = logger;
	}

	[HttpGet("GetAll")]
	public async Task<ActionResult<List<ProductResponse>>> GetAll()
	{
		var products = await _productsService.GetAllProducts();

		var response = products
			.Select(p => new ProductResponse
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				CategoryId = p.CategoryId,
				Image = p.Image,
				IsAvailable = p.IsAvailable
			});

		return Ok(response);
	}

	[HttpPost("Create")]
	public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductRequest request)
	{
		return await _productsService.CreateProduct(request);
	}

	[HttpPatch("Update")]
	public async Task<ActionResult<Guid>> UpdateInfo(Guid id, [FromBody] UpdateProductRequest request)
	{
		return await _productsService.UpdateInfo(request, id);
	}

	[HttpDelete("Delete")]
	public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
	{
		var result = await _productsService.DeleteProduct(productId);

		if (result.IsFailure)
		{
			_logger.LogError(result.Error);
			return BadRequest(result.Error);
		}

		return Ok(result.Value);
	}
}
