using E_Shop.Contracts.Commands;
using E_Shop.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Application.Products.Handlers.Create;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, ActionResult<Guid>>
{
	private readonly IProductsService _productsService;

	public CreateProductHandler(IProductsService productsService)
	{
		_productsService = productsService;
	}

	public async Task<ActionResult<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		return await _productsService.CreateProduct(request);
	}
}
