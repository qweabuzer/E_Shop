
using CSharpFunctionalExtensions;
using E_Shop.Contracts.Contracts.Products;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Core.Interfaces;

public interface IProductsService
{
	Task<List<Product>> GetAllProducts();
	Task<ActionResult<Guid>> CreateProduct(CreateProductRequest request);
	Task<ActionResult<Guid>> UpdateInfo(UpdateProductRequest request, Guid id);
	Task<Result<Guid>> DeleteProduct(Guid id);
}
