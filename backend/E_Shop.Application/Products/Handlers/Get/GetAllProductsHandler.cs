using E_Shop.Contracts.Contracts.Products;
using E_Shop.Contracts.Queries;
using E_Shop.Core.Interfaces;
using MediatR;

namespace E_Shop.Application.Products.Handlers.Get;
public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
	private readonly IProductsService _productsService;

	public GetAllProductsHandler(IProductsService productsService)
	{
		_productsService = productsService;
	}
	public async Task<List<ProductResponse>> Handle(GetAllProductsQuery query, CancellationToken ct)
	{
		return await _productsService.GetAllProducts();
	}
}
