using E_Shop.Contracts.Commands;
using E_Shop.Contracts.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Core.Interfaces;

public interface IProductsService
{
	Task<List<ProductResponse>> GetAllProducts();
	Task<ActionResult<Guid>> CreateProduct(CreateProductCommand command);
	Task<ActionResult<Guid>> UpdateInfo(UpdateProductCommand command);
	Task<ActionResult<Guid>> DeleteProduct(Guid id);
}
