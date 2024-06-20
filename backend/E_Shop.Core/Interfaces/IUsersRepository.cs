using E_Shop.Core.Models;

namespace E_Shop.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAll();
        Task<Users> Get(string login, string password);
        Task<Guid> Create(Users user);
        Task<Guid> Update(Guid id, string name, string email, string login, string password, string image);
        Task<Guid> Delete(Guid id);
    }
}
