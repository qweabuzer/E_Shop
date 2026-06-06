using E_Shop.Contracts.Commands;
using E_Shop.Contracts.Contracts.Products;
using E_Shop.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IMediator _mediator;
	public ProductsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("GetAll")]
	public async Task<ActionResult<List<ProductResponse>>> GetAll()
	{
		var query = new GetAllProductsQuery();

		return await _mediator.Send(query);
	}

	[HttpPost("Create")]
	public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductRequest request)
	{
		var command = new CreateProductCommand
		{
			Name = request.Name,
			Description = request.Description,
			Price = request.Price,
			CategoryId = request.CategoryId,
			Image = request.Image,
			IsAvailable = request.IsAvailable
		};

		return await _mediator.Send(command);
	}

	[HttpPatch("Update")]
	public async Task<ActionResult<Guid>> UpdateInfo(Guid id, [FromBody] UpdateProductRequest request)
	{
		var command = new UpdateProductCommand
		{
			Id = id,
			Name = request.Name,
			Description = request.Description,
			Price = request.Price,
			CategoryId = request.CategoryId,
			Image = request.Image,
			IsAvailable = request.IsAvailable
		};

		return await _mediator.Send(command);
	}

	[HttpDelete("Delete")]
	public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
	{
		var command = new DeleteProductCommand { Id = productId };

		return await _mediator.Send(command);
	}
}
