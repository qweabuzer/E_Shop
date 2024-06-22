using CSharpFunctionalExtensions;
using E_Shop.Core.Models;

namespace E_Shop.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Result<Guid>> CreateCategory(Category category);
        Task<Result<Guid>> UpdateInfo(Guid id, string name, string description);
        Task<Result<Guid>> Delete(Guid id);
    }
}
