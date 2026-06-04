using CSharpFunctionalExtensions;
using E_Shop.Contracts.Contracts.Products;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Application.Services;

//todo
public class ProductsService : IProductsService
{
	private readonly IProductsRepository _productsRepository;

	public ProductsService(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository;
	}
	public async Task<ActionResult<Guid>> CreateProduct(CreateProductRequest request)
	{
		var description = request.Description;
		if (string.IsNullOrWhiteSpace(description))
		{
			description = Product.NoDescription;
		}

		var image = request.Image;
		if (string.IsNullOrWhiteSpace(image))
		{
			image = Product.NoImage;
		}

		var product = new Product
		{
			Id = Guid.NewGuid(),
			Name = request.Name,
			Description = description,
			Price = request.Price,
			CategoryId = request.CategoryId,
			Image = image,
			IsAvailable = request.IsAvailable
		};

		var result = await _productsRepository.Create(product);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("ошибка при создании товара");
		}

		return new OkObjectResult(result);
	}

	public async Task<Result<Guid>> DeleteProduct(Guid id)
	{
		var result = await _productsRepository.Delete(id);

		if (result == Guid.Empty)
			return Result.Failure<Guid>("Ошибка при удалении товара");

		return Result.Success<Guid>(result);
	}

	public async Task<List<Product>> GetAllProducts()
	{
		return await _productsRepository.GetAll();
	}

	public async Task<ActionResult<Guid>> UpdateInfo(UpdateProductRequest request, Guid id)
	{
		var result = await _productsRepository.Update(id,
			request.Name,
			request.Description,
			request.Price,
			request.CategoryId,
			request.Image,
			request.IsAvailable);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("ошибка обновления данных");
		}

		return new OkObjectResult(result);
	}
}
