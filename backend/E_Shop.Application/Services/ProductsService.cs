using CSharpFunctionalExtensions;
using E_Shop.Contracts.Commands;
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
	public async Task<ActionResult<Guid>> CreateProduct(CreateProductCommand command)
	{
		var description = command.Description;
		if (string.IsNullOrWhiteSpace(description))
		{
			description = Product.NoDescription;
		}

		var image = command.Image;
		if (string.IsNullOrWhiteSpace(image))
		{
			image = Product.NoImage;
		}

		var product = new Product
		{
			Name = command.Name,
			Description = description,
			Price = command.Price,
			CategoryId = command.CategoryId,
			Image = image,
			IsAvailable = command.IsAvailable
		};

		var result = await _productsRepository.Create(product);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("ошибка при создании товара");
		}

		return new OkObjectResult(result);
	}

	public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
	{
		var result = await _productsRepository.Delete(id);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("ошибка при удалении товара");
		}

		return new OkObjectResult(result);
	}

	public async Task<List<ProductResponse>> GetAllProducts()
	{
		var products = await _productsRepository.GetAll();

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
			}).ToList();

		return response;
	}

	public async Task<ActionResult<Guid>> UpdateInfo(UpdateProductCommand command)
	{
		var result = await _productsRepository.Update(command.Id,
			command.Name,
			command.Description,
			command.Price,
			command.CategoryId,
			command.Image,
			command.IsAvailable);

		if (result == Guid.Empty)
		{
			return new BadRequestObjectResult("ошибка обновления данных");
		}

		return new OkObjectResult(result);
	}
}
