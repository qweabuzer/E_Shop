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
            return await _productsRepository.Create(product);
        }

        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productsRepository.Delete(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsRepository.GetAll();
        }

        public async Task<Result<Guid>> UpdateInfo(Guid id, string name, string description, decimal price, Guid categoryId, string image, bool isAvailable)
        {
            return await _productsRepository.Update(id, name, description, price, categoryId, image, isAvailable);
        }
    }
}
