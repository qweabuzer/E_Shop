
using CSharpFunctionalExtensions;
using E_Shop.Core.Models;

namespace E_Shop.Core.Interfaces
{
    public interface IProductsService
    {
        Task<List<Product>> GetAllProducts();
        Task<Result<Guid>> CreateProduct(Product product);
        Task<Result<Guid>> UpdateInfo(Guid id, string name, string description, decimal price, Guid categoryId, string image, bool isAvailable);
        Task<Guid> DeleteProduct(Guid id);
    }
}
