using E_Shop.Contracts.Commands;
using E_Shop.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Application.Products.Handlers.Update;
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ActionResult<Guid>>
{
	private readonly IProductsService _productsService;

	public UpdateProductHandler(IProductsService productService)
	{
		_productsService = productService;
	}

	public async Task<ActionResult<Guid>> Handle(UpdateProductCommand request, CancellationToken ct)
	{
		return await _productsService.UpdateInfo(request);
	}
}
