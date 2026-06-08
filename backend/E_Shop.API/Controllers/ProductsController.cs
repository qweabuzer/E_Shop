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
		return await _mediator.Send(new GetAllProductsQuery());
	}

	[HttpPost("Create")]
	public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductRequest request)
	{
		return await _mediator.Send(request);
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
		return await _mediator.Send(new DeleteProductCommand { Id = productId });
	}
}
