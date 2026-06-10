using E_Shop.Contracts.Commands;
using E_Shop.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Application.Products.Handlers.Delete;
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ActionResult<Guid>>
{
	private readonly IProductsService _productsService;

	public DeleteProductHandler(IProductsService productsService)
	{
		_productsService = productsService;
	}
	public async Task<ActionResult<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		return await _productsService.DeleteProduct(request.Id);
	}
}
