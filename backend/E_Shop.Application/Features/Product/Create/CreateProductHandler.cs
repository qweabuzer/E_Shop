using E_Shop.Contracts.Contracts.Products;
using E_Shop.Core.Interfaces;
using MediatR;
using ProductModel = E_Shop.Core.Models.Product;

namespace E_Shop.Application.Features.Product.Create;
public class CreateProductHandler : IRequestHandler<CreateProductRequest, Guid>
{
	private readonly IProductsRepository _productsRepository;
	private const string DefaultImage = "https://topzero.com/wp-content/uploads/2020/06/topzero-products-Malmo-Matte-Black-TZ-PE458M-image-003.jpg";

	public CreateProductHandler(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository;
	}

	public async Task<Guid> Handle(CreateProductRequest request, CancellationToken cancellationToken)
	{
		var product = new ProductModel
		{
			Name = request.Name,
			Description = request.Description,
			Price = request.Price,
			CategoryId = request.CategoryId,
			Image = string.IsNullOrWhiteSpace(request.Image) ? DefaultImage : request.Image,
			IsAvailable = request.IsAvailable
		};

		var result = await _productsRepository.Create(product);

		if (result == Guid.Empty)
		{
			throw new InvalidOperationException("ошибка при создании товара");
		}

		return result;
	}
}
