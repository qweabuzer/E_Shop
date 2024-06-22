using CSharpFunctionalExtensions;
using E_Shop.Core.Interfaces;
using E_Shop.Core.Models;
using E_Shop.DataAccess.Repositories;

namespace E_Shop.Application.Services
{
    //todo
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<Result<Guid>> CreateProduct(Product product)
        {
            var result = await _productsRepository.Create(product);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка при создании пользователя");

            return Result.Success<Guid>(result);
        }

        public async Task<Result<Guid>> DeleteProduct(Guid id)
        {
            var result = await _productsRepository.Delete(id);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка при удалении пользователя");

            return Result.Success<Guid>(result);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsRepository.GetAll();
        }

        public async Task<Result<Guid>> UpdateInfo(Guid id, string name, string description, decimal? price, Guid? categoryId, string image, bool? isAvailable)
        {
            var result =  await _productsRepository.Update(id, name, description, price, categoryId, image, isAvailable);

            if (result == Guid.Empty)
                return Result.Failure<Guid>("Ошибка обновления данных");

            return Result.Success<Guid>(result);
        }
    }
}
