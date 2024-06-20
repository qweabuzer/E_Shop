using E_Shop.Core.Models;

namespace E_Shop.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAll();
        Task<Guid> Create(Product product);
        Task<Guid> Update(Guid id, string name, string description, decimal price, Guid categoryId, string image, bool isAvailable);
        Task<Guid> Delete(Guid id);
    }
}