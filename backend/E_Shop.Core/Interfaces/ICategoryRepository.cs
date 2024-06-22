
using E_Shop.Core.Models;

namespace E_Shop.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Guid> Create(Category category);
        Task<Guid> Update(Guid id, string name, string description);
        Task<Guid> Delete(Guid id);
    }
}
